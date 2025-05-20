using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MealyMachineCoinGame
{
    public partial class Form1 : Form
    {
        private enum GameState { Start, Collecting, LevelUp, GameOver }
        private GameState currentState = GameState.Start;
        private List<Button> coins = new List<Button>();
        private Button trueCoin;
        private int coinCount = 0;
        private int level = 1;
        private int timeRemaining = 40;
        private Timer gameTimer;
        private Timer stateTransitionTimer;
        private Timer countdownTimer;
        private Timer heartbeatTimer;
        private Random rand = new Random();
        private int countdownTime;
        private bool isHeartbeatGrowing = true;
        private int heartbeatMaxFontSize = 28;
        private int heartbeatMinFontSize = 24;
        private Timer coinMovementTimer;





        [DllImport("winmm.dll", SetLastError = true)]
        public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);
        private const uint SND_ASYNC = 0x0001;
        private const uint SND_FILENAME = 0x00020000;

        public Form1()
        {
            InitializeComponent();
            InitializeTimers();
            UpdateUI("Click Start to begin.");
        }

        private void InitializeTimers()
        {
            gameTimer = new Timer { Interval = 1000 };
            gameTimer.Tick += GameTimer_Tick;

            stateTransitionTimer = new Timer { Interval = 2000 };
            stateTransitionTimer.Tick += StateTransitionTimer_Tick;

            countdownTimer = new Timer { Interval = 1000 };
            countdownTimer.Tick += CountdownTimer_Tick;

            heartbeatTimer = new Timer { Interval = 500 };  // Heartbeat pulse every 0.5s
            heartbeatTimer.Tick += HeartbeatTimer_Tick;

            // Initialize the new coin movement timer
            coinMovementTimer = new Timer { Interval = 2000 }; // Move coins every 2 seconds
            coinMovementTimer.Tick += CoinMovementTimer_Tick;
        }


        private void HeartbeatTimer_Tick(object sender, EventArgs e)
        {
            if (isHeartbeatGrowing)
            {
                // Increase font size to simulate pulse
                lblTimer.Font = new Font("Arial", heartbeatMaxFontSize, FontStyle.Bold);
            }
            else
            {
                // Decrease font size to simulate pulse
                lblTimer.Font = new Font("Arial", heartbeatMinFontSize, FontStyle.Bold);
            }

            // Toggle the heartbeat effect: grow or shrink
            isHeartbeatGrowing = !isHeartbeatGrowing;
        }



        private void StateTransitionTimer_Tick(object sender, EventArgs e)
        {
            stateTransitionTimer.Stop();
            SetState(GameState.Collecting, "🔁 Game started! Find the true coin.");

            // Start heartbeat animation when time drops to 10 seconds
            if (timeRemaining <= 10 && !heartbeatTimer.Enabled)
            {
                heartbeatTimer.Start();  // Start the heartbeat pulse animation
            }
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            lblTimer.Text = $"Time: {timeRemaining}s";

            // Start heartbeat animation only when the timer reaches 10 seconds
            if (timeRemaining == 10 && !heartbeatTimer.Enabled)
            {
                heartbeatTimer.Start();  // Start the heartbeat pulse animation
            }

            // Stop heartbeat animation when time runs out
            if (timeRemaining == 0)
            {
                heartbeatTimer.Stop(); // Stop the heartbeat pulse animation
                PlaySound(level > 7 ? @"goodresult-82807.wav" : @"Voicy_Fail.wav", IntPtr.Zero, SND_ASYNC | SND_FILENAME);
                SetState(GameState.GameOver, level > 7 ? "🎉 Congratulations! You've completed all levels." : "⏰ Time's up! Game Over.");
                gameTimer.Stop();
                DisableCoinButtons();
            }
        }





        private void InitializeCoins()
        {
            pnlCoinsBox.Controls.Clear();
            coins.Clear();

            int totalCoins = 10;
            trueCoin = CreateCoin(true);
            coins.Add(trueCoin);
            pnlCoinsBox.Controls.Add(trueCoin);

            for (int i = 1; i < totalCoins; i++)
            {
                Button fakeCoin = CreateCoin(false);
                coins.Add(fakeCoin);
                pnlCoinsBox.Controls.Add(fakeCoin);
            }
        }

        private Button CreateCoin(bool isTrueCoin)
        {
            int coinSize = 80;
            Button coinButton = new Button
            {
                Size = new Size(coinSize, coinSize),
                Font = new Font("Segoe UI", coinSize / 2, FontStyle.Bold),
                Text = "🪙",
                Location = GetRandomLocation(),
                Tag = isTrueCoin ? "TrueCoin" : "FakeCoin",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                BackColor = isTrueCoin ? Color.FromArgb(255, 235, 150) : Color.Gold
            };
            coinButton.FlatAppearance.BorderSize = 0;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, coinButton.Width, coinButton.Height);
            coinButton.Region = new Region(path);

            coinButton.Click += CoinButton_Click;
            return coinButton;
        }

        private Point GetRandomLocation()
        {
            return new Point(rand.Next(0, pnlCoinsBox.Width - 60), rand.Next(0, pnlCoinsBox.Height - 60));
        }

        private void CoinButton_Click(object sender, EventArgs e)
        {
            if (currentState != GameState.Collecting) return;

            Button clickedCoin = (Button)sender;

            if (clickedCoin == trueCoin)
            {
                AnimatePop(clickedCoin, () =>
                {
                    coinCount++;
                    SetState(GameState.Collecting, $"✅ Correct! Coins: {coinCount}");
                    PlaySound("coin-drop-1.wav", IntPtr.Zero, SND_ASYNC | SND_FILENAME);

                    if (coinCount >= RequiredCoinsForLevel())
                    {
                        if (level == 7)
                        {
                            PlaySound("goodresult-82807.wav", IntPtr.Zero, SND_ASYNC | SND_FILENAME);
                            SetState(GameState.GameOver, "🎉 Congratulations! You've completed all 7 levels.");
                            gameTimer.Stop();
                            DisableCoinButtons();
                        }
                        else
                        {
                            LevelUp();
                        }
                    }
                    else
                    {
                        MoveCoins();
                    }
                });
            }
            else
            {
                coinCount = Math.Max(0, coinCount - 1);
                SetState(GameState.Collecting, $"❌ Wrong coin! Coins: {coinCount}");

                AnimateBomb(clickedCoin, () =>
                {
                    PlaySound(@"error-170796 (online-audio-converter.com).wav", IntPtr.Zero, SND_ASYNC | SND_FILENAME);
                    MoveCoins();
                });
            }
        }

        private void AnimateBomb(Button coin, Action onComplete)
        {
            int originalSize = coin.Width;
            int maxSize = originalSize + 20;
            int minSize = originalSize - 10;
            int steps = 10;
            int step = 0;

            coin.BackColor = Color.FromArgb(255, 99, 99);

            Timer bombTimer = new Timer { Interval = 15 };
            bombTimer.Tick += (s, e) =>
            {
                if (step < steps)
                {
                    coin.Size = new Size(Math.Min(coin.Width + 2, maxSize), Math.Min(coin.Height + 2, maxSize));
                }
                else if (step < steps * 2)
                {
                    coin.Size = new Size(Math.Max(coin.Width - 3, minSize), Math.Max(coin.Height - 3, minSize));
                }
                else
                {
                    bombTimer.Stop();
                    coin.Size = new Size(originalSize, originalSize);
                    coin.BackColor = Color.Gold;
                    onComplete?.Invoke();
                }
                step++;
            };

            bombTimer.Start();
        }

        private void AnimatePop(Button coin, Action onComplete)
        {
            int originalSize = coin.Width;
            int popSteps = 5;
            int step = 0;
            Timer popTimer = new Timer { Interval = 30 };

            popTimer.Tick += (s, e) =>
            {
                if (step < popSteps)
                {
                    coin.Size = new Size(coin.Width + 4, coin.Height + 4);
                    coin.Font = new Font(coin.Font.FontFamily, coin.Font.Size + 1, FontStyle.Bold);
                    step++;
                }
                else if (step < popSteps * 2)
                {
                    coin.Size = new Size(coin.Width - 4, coin.Height - 4);
                    coin.Font = new Font(coin.Font.FontFamily, coin.Font.Size - 1, FontStyle.Bold);
                    step++;
                }
                else
                {
                    popTimer.Stop();
                    coin.Size = new Size(originalSize, originalSize);
                    coin.Font = new Font("Segoe UI", originalSize / 2, FontStyle.Bold);
                    onComplete?.Invoke();
                }
            };

            popTimer.Start();
        }

        private void MoveCoins()
        {
            foreach (Button coin in coins)
            {
                coin.Location = GetRandomLocation();
            }
        }


        private void DisableCoinButtons()
        {
            foreach (Button coin in coins)
                coin.Enabled = false;
        }

        private void EnableCoinButtons()
        {
            foreach (Button coin in coins)
                coin.Enabled = true;
        }

        private int RequiredCoinsForLevel()
        {
            return 5 + (level - 1) * 2;
        }

        private void LevelUp()
        {
            if (level >= 7)
            {
                SetState(GameState.GameOver, "🎉 Congratulations! You've completed all 7 levels. 😎🎉");
                gameTimer.Stop();
                DisableCoinButtons();

                // Start the coin movement timer when reaching level 7
                coinMovementTimer.Start();  // Start moving coins every 2 seconds
            }
            else
            {
                level++;
                coinCount = 0;

                PlaySound(@"Voicy_1-Up Mushroom.wav", IntPtr.Zero, SND_ASYNC | SND_FILENAME);

                string levelUpMessage = $"🚀 Level {level} Up! 🎈🎉🎊🎯😜";

                // Enlarge the level-up message font
                label9.Font = new Font(label9.Font.FontFamily, 20, FontStyle.Bold);
                SetState(GameState.LevelUp, levelUpMessage);

                Timer levelUpDelay = new Timer { Interval = 2000 };
                levelUpDelay.Tick += (s, e) =>
                {
                    levelUpDelay.Stop();
                    timeRemaining = 40;
                    lblTimer.Text = $"Time: {timeRemaining}s";
                    InitializeCoins();
                    EnableCoinButtons();

                    // Reset the font back to normal size
                    label9.Font = new Font(label9.Font.FontFamily, 12, FontStyle.Regular);
                    SetState(GameState.Collecting, $"🎯 Level {level} started! Find the true coin! 🤑🎉");

                    // Stop heartbeat animation when resetting after level-up
                    heartbeatTimer.Stop(); // Ensure heartbeat is stopped when resetting the game

                    // Start the game countdown again (don't start heartbeat yet)
                };
                levelUpDelay.Start();
            }
        }


        private void SetState(GameState newState, string message)
        {
            currentState = newState;
            label12.Text = $"State: {currentState}";

            // Show collected coins out of the required coins for the current level
            label11.Text = $"Coins: {coinCount}/{RequiredCoinsForLevel()}"; // This line is the key change

            label10.Text = $"Level: {level}/7";
            label9.Text = message;

            if (newState == GameState.GameOver)
            {
                gameTimer.Stop();
                ShowGameOverForm(message);
            }
        }


        private void UpdateUI(string message)
        {
            label12.Text = $"State: {currentState}";  // Updates current state label
            label11.Text = $"Coins: {coinCount}";     // Updates coin count label
            label10.Text = $"Level: {level}";         // Updates level label
            label9.Text = message;                 // Updates the game message
        }


        private void ShowGameOverForm(string message)
        {
            GameOverForm gameOverForm = new GameOverForm(message);
            if (gameOverForm.ShowDialog() == DialogResult.OK)
            {
                // Enable the Start button so the player can manually restart
                btnStartRestart.Enabled = true;
                btnStartRestart.Text = "Start Game";

                // Optionally update message label
                label9.Text = "Click Start to play again.";

                // Do NOT call PrepareGameWithCountdown() here
            }
        }


        private void btnStartRestart_Click(object sender, EventArgs e)
        {
            PrepareGameWithCountdown();
        }

        private void PrepareGameWithCountdown()
        {
            coinCount = 0;
            level = 1;
            timeRemaining = 40;
            lblTimer.Text = $"Time: {timeRemaining}s";

            countdownTime = 3;
            label9.Text = $"Game starting in {countdownTime}...";
            label9.Font = new Font("Arial", heartbeatMaxFontSize, FontStyle.Bold);
            label11.Text = $"Coins: {coinCount}";
            label10.Text = $"Level: {level}";
            label12.Text = "State: Start"; // Updated from lblState to label12

            DisableCoinButtons();
            btnStartRestart.Enabled = false;
            gameTimer.Stop();

            heartbeatTimer.Stop(); // Stop heartbeat animation when preparing to restart the game
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            label9.Text = $"Starting in {countdownTime}...";
            PlaySound(@"timer-digital-countdown-bop-audio-1-00-04-[AudioTrimmer.com].wav", IntPtr.Zero, SND_ASYNC | SND_FILENAME);
            countdownTime--;

            if (countdownTime < 0)
            {
                countdownTimer.Stop();
                heartbeatTimer.Stop(); // Stop heartbeat after countdown finishes
                label9.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                label9.Text = "🔁 Game started! Find the true coin.";
                btnStartRestart.Enabled = true;
                StartGameAfterCountdown();
            }
        }

        private void StartGameAfterCountdown()
        {
            label9.Text = "🔁 Game started! Find the true coin.";
            gameTimer.Start();
            EnableCoinButtons();
            InitializeCoins();
            stateTransitionTimer.Start();
            SetState(GameState.Collecting, "🔁 Game started! Find the true coin.");
            btnStartRestart.Text = "Restart Game";
        }

        private void CoinMovementTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control coin in pnlCoinsBox.Controls)
            {
                if (coin is Button) // Assuming your coins are buttons
                {
                    // Move the coin to a random location within the panel
                    coin.Location = GetRandomLocation();
                }
            }
        }



        private void pnlCoinsBox_Paint(object sender, PaintEventArgs e) { }

        private void lblLevel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

    }
}

