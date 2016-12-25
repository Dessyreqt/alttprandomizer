using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using AlttpRandomizer.IO;
using AlttpRandomizer.Net;
using AlttpRandomizer.Properties;
using AlttpRandomizer.Random;
using AlttpRandomizer.Rom;

namespace AlttpRandomizer
{
    public partial class MainForm : Form
    {
        private Thread checkUpdateThread;

        public MainForm()
        {
            InitializeSettings();
            InitializeComponent();
        }

        private void InitializeSettings()
        {
            // this fixes an issue with running on wine
            Settings.Default.SramTrace = Settings.Default.SramTrace;
            Settings.Default.OutputFile = Settings.Default.OutputFile;
            Settings.Default.RandomizerDifficulty = Settings.Default.RandomizerDifficulty;
            Settings.Default.CreateSpoilerLog = Settings.Default.CreateSpoilerLog;
            Settings.Default.HeartBeepSpeed = Settings.Default.HeartBeepSpeed;
            Settings.Default.CheckForUpdates = Settings.Default.CheckForUpdates;
        }

        private void create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(seed.Text))
            {
                SetSeedBasedOnDifficulty();
            }

            ClearOutput();

            var difficulty = GetRandomizerDifficulty();

            if (difficulty == RandomizerDifficulty.None)
            {
                return;
            }

            int parsedSeed;

            if (!int.TryParse(seed.Text, out parsedSeed))
            {
                MessageBox.Show("Seed must be numeric or blank.", "Seed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteOutput("Seed must be numeric or blank.");
            }
            else
            {
                try
                {
                    var romLocations = RomLocationsFactory.GetRomLocations(difficulty);
                    RandomizerLog log = null;

                    if (createSpoilerLog.Checked)
                    {
                        log = new RandomizerLog(string.Format(romLocations.SeedFileString, parsedSeed));
                    }

                    seed.Text = string.Format(romLocations.SeedFileString, parsedSeed);

                    CreateRom(romLocations, log, difficulty, parsedSeed);

                    var outputString = new StringBuilder();

                    outputString.AppendFormat("Done!{0}{0}{0}Seed: ", Environment.NewLine);
                    outputString.AppendFormat(romLocations.SeedFileString, parsedSeed);
                    outputString.AppendFormat(" ({0} Difficulty){1}{1}", romLocations.DifficultyName, Environment.NewLine);

                    WriteOutput(outputString.ToString());
                }
                catch (RandomizationException ex)
                {
                    WriteOutput(ex.ToString());
                }

            }

            SaveRandomizerSettings();
        }

        private void SaveRandomizerSettings()
        {
            Settings.Default.SramTrace = sramTrace.Checked;
            Settings.Default.CreateSpoilerLog = createSpoilerLog.Checked;
            Settings.Default.RandomizerDifficulty = randomizerDifficulty.SelectedItem.ToString();
            Settings.Default.HeartBeepSpeed = heartBeepSpeed.SelectedItem.ToString();
            Settings.Default.CheckForUpdates = checkForUpdates.Checked;

            Settings.Default.Save();
        }

        private void CreateRom(IRomLocations romLocations, RandomizerLog log, RandomizerDifficulty difficulty, int parsedSeed)
        {
            var randomizer = new Randomizer(parsedSeed, romLocations, log);
            var options = new RandomizerOptions
                            {
                                Filename = filename.Text,
                                SramTrace = sramTrace.Checked,
                                Difficulty = difficulty,
                                HeartBeepSpeed = GetHeartBeepSpeed(),
                            };

            randomizer.CreateRom(options);
        }

        private HeartBeepSpeed GetHeartBeepSpeed()
        {
            HeartBeepSpeed retVal;

            if (Enum.TryParse(heartBeepSpeed.SelectedItem.ToString(), true, out retVal))
            {
                return retVal;
            }

            return HeartBeepSpeed.Normal;
        }

        private void CreateSpoilerLog(RandomizerDifficulty difficulty)
        {
            int parsedSeed;

            if (!int.TryParse(seed.Text, out parsedSeed))
            {
                MessageBox.Show("Seed must be numeric or blank.", "Seed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteOutput("Seed must be numeric or blank.");
            }
            else
            {
                var romPlms = RomLocationsFactory.GetRomLocations(difficulty);
                RandomizerLog log = new RandomizerLog(string.Format(romPlms.SeedFileString, parsedSeed));

                seed.Text = string.Format(romPlms.SeedFileString, parsedSeed);

                try
                {
                    var randomizer = new Randomizer(parsedSeed, romPlms, log);
                    WriteOutput(randomizer.CreateRom(new RandomizerOptions { SpoilerOnly = true, Difficulty = difficulty}));
                }
                catch (RandomizationException ex)
                {
                    WriteOutput(ex.ToString());
                }
            }
        }

        private RandomizerDifficulty GetRandomizerDifficulty()
        {
            RandomizerDifficulty difficulty;

            if (seed.Text.ToUpper().Contains("C"))
            {
                randomizerDifficulty.SelectedItem = "Casual";
                seed.Text = seed.Text.ToUpper().Replace("C", "");
                difficulty = RandomizerDifficulty.Casual;
            }
            if (seed.Text.ToUpper().Contains("G"))
            {
                randomizerDifficulty.SelectedItem = "Glitched";
                seed.Text = seed.Text.ToUpper().Replace("G", "");
                difficulty = RandomizerDifficulty.Glitched;
            }
            else
            {
                switch (randomizerDifficulty.SelectedItem.ToString())
                {
                    case "Casual":
                        difficulty = RandomizerDifficulty.Casual;
                        break;
                    case "Glitched":
                        difficulty = RandomizerDifficulty.Glitched;
                        break;
                    default:
                        MessageBox.Show("Please select a difficulty.", "Select Difficulty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        WriteOutput("Please select a difficulty.");
                        return RandomizerDifficulty.None;
                }
            }

            return difficulty;
        }

        private void SetSeedBasedOnDifficulty()
        {
            switch (randomizerDifficulty.SelectedItem.ToString())
            {
                case "Casual":
                    seed.Text = string.Format("C{0:0000000}", (new SeedRandom()).Next(10000000));
                    break;
                case "Glitched":
                    seed.Text = string.Format("G{0:0000000}", (new SeedRandom()).Next(10000000));
                    break;
                default:
                    MessageBox.Show("Please select a difficulty.", "Select Difficulty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    WriteOutput("Please select a difficulty.");
                    break;
            }
        }

        private void ClearOutput()
        {
            output.Text = "";
        }

        private void WriteOutput(string text)
        {
            output.Text += text;
            Application.DoEvents();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var info = new FileInfo(Regex.Replace(filename.Text, "<.*>", ""));
            var saveFileDialog = new SaveFileDialog { Filter = "All files (*.*)|*.*", FilterIndex = 2, RestoreDirectory = true, InitialDirectory = info.DirectoryName, FileName = info.Name };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename.Text = saveFileDialog.FileName;
                MessageBox.Show("Remember to hit \"create\" to create the rom.", "Remember to create the rom!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void filename_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.OutputFile = filename.Text;
            Settings.Default.Save();
        }

        private void filename_Leave(object sender, EventArgs e)
        {
            var senderText = (TextBox)sender;

            if (!senderText.Text.Contains("."))
            {
                senderText.Text += ".sfc";
            }
        }

        private void report_Click(object sender, EventArgs e)
        {
            if (output.Text.Contains("RandomizationException"))
            {
                var title = Uri.EscapeUriString(output.Text.Substring(47, output.Text.IndexOf(" --->", StringComparison.Ordinal) - 47));
                var message = Uri.EscapeUriString(output.Text.Substring(0, output.Text.IndexOf("   at", StringComparison.Ordinal)));
                Help.ShowHelp(null, string.Format("https://gitreports.com/issue/Dessyreqt/alttprandomizer?issue_title=[v{0}]%20{1}&details=[v{0}]%0A%0A{2}", RandomizerVersion.CurrentDisplay, title, message));
            }
            else
            {
                Help.ShowHelp(null, string.Format("https://gitreports.com/issue/Dessyreqt/alttprandomizer?issue_title=[v{0}]%20Anonymous%20Issue&details=[v{0}]%0A%0A", RandomizerVersion.CurrentDisplay));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            filename.Text = Settings.Default.OutputFile;
            createSpoilerLog.Checked = Settings.Default.CreateSpoilerLog;
            sramTrace.Checked = Settings.Default.SramTrace;
            Text = string.Format("A Link to the Past Randomizer v{0}", RandomizerVersion.CurrentDisplay);
            randomizerDifficulty.SelectedItem = Settings.Default.RandomizerDifficulty;
            heartBeepSpeed.SelectedItem = Settings.Default.HeartBeepSpeed;
            checkForUpdates.Checked = Settings.Default.CheckForUpdates;

            if (checkForUpdates.Checked)
            {
                RunCheckUpdate();
            }

            if (RandomizerVersion.Debug)
            {
                create.BackColor = Color.DarkRed;
                Text += " *** DEBUG ***";
            }
        }

        private void RunCheckUpdate()
        {
            checkUpdateThread = new Thread(RandomizerVersion.CheckUpdate);
            checkUpdateThread.SetApartmentState(ApartmentState.STA);
            checkUpdateThread.Start();
        }

        private void randomSpoiler_Click(object sender, EventArgs e)
        {
            SetSeedBasedOnDifficulty();

            ClearOutput();

            var difficulty = GetRandomizerDifficulty();
            CreateSpoilerLog(difficulty);
        }

        private void listSpoiler_Click(object sender, EventArgs e)
        {
            var difficulty = GetRandomizerDifficulty();
            CreateSpoilerLog(difficulty);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRandomizerSettings();
        }

        private void bulkCreate_Click(object sender, EventArgs e)
        {
            if (!filename.Text.Contains("<seed>"))
            {
                MessageBox.Show("Bulk create requires \"<seed>\" be in the file name.", "Filename Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteOutput("Bulk create requires \"<seed>\" be in the file name.");
            }
            else
            {
                ClearOutput();

                var difficulty = GetRandomizerDifficulty();

                if (difficulty == RandomizerDifficulty.None)
                {
                    return;
                }

                int successCount = 0;
                int failCount = 0;

                for (int seedNum = 0; seedNum < bulkCreateCount.Value; seedNum++)
                {
                    int parsedSeed = new SeedRandom().Next(10000000);
                    var romLocations = RomLocationsFactory.GetRomLocations(difficulty);
                    RandomizerLog log = null;

                    var outputString = new StringBuilder();
                    outputString.Append("Creating Seed: ");
                    outputString.AppendFormat(romLocations.SeedFileString, parsedSeed);
                    outputString.AppendFormat(" ({0} Difficulty){1}", romLocations.DifficultyName, Environment.NewLine);
                    WriteOutput(outputString.ToString());

                    if (createSpoilerLog.Checked)
                    {
                        log = new RandomizerLog(string.Format(romLocations.SeedFileString, parsedSeed));
                    }

                    seed.Text = string.Format(romLocations.SeedFileString, parsedSeed);

                    try
                    {

                        CreateRom(romLocations, log, difficulty, parsedSeed);

                        outputString = new StringBuilder();
                        outputString.AppendFormat("Completed Seed: ");
                        outputString.AppendFormat(romLocations.SeedFileString, parsedSeed);
                        outputString.AppendFormat(" ({0} Difficulty){1}{1}", romLocations.DifficultyName, Environment.NewLine);
                        WriteOutput(outputString.ToString());

                        successCount++;
                    }
                    catch (RandomizationException ex)
                    {
                        outputString = new StringBuilder();
                        outputString.AppendFormat("FAILED Creating Seed: ");
                        outputString.AppendFormat(romLocations.SeedFileString, parsedSeed);
                        outputString.AppendFormat(" ({0} Difficulty) - {1}{2}{2}", romLocations.DifficultyName, ex.Message, Environment.NewLine);
                        WriteOutput(outputString.ToString());

                        failCount++;
                        seedNum--;
                    }
                }

                WriteOutput(string.Format("Completed! {0} successful", successCount));
                if (failCount > 0)
                {
                    WriteOutput(string.Format(", {0} failed. ", failCount));
                }
            }

            SaveRandomizerSettings();
        }
    }
}
