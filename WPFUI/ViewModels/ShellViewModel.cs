using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Screen
    {
        #region Private backing fields

        /// <summary>
        /// Holds the private field for the screen text
        /// </summary>
        private string _screen = "0000";

        /// <summary>
        /// A private list used to manipulate the screen values
        /// </summary>
        private List<string> _screenList = new List<string>();

        /// <summary>
        /// Holds the passcode for entry
        /// </summary>
        private string _passcode = "1234";

        /// <summary>
        /// Holds the unlocked value
        /// </summary>
        private bool _isUnlocked = false;

        /// <summary>
        /// Determines whether the reset button was pressed
        /// during the wait period
        /// </summary>
        private bool _resetPressed = false;

        #endregion Private backing fields

        #region Private methods

        /// <summary>
        /// Updates the private List of the screen values
        /// </summary>
        private void UpdatePrivateList()
        {
            _screenList = Screen.Select(c => c.ToString()).ToList();
        }

        /// <summary>
        /// Updates the public string for the screen text
        /// </summary>
        private void UpdatePublicString()
        {
            Screen = string.Join("", _screenList);
        }

        /// <summary>
        /// Updates the list to add a new number and removes the first
        /// </summary>
        private void AddNewButtonPress(string number)
        {
            _screenList.RemoveAt(0);
            _screenList.Add(number);
        }

        /// <summary>
        /// Used to reset the screenList to "0000" and update the screen string
        /// </summary>
        private void ResetScreen()
        {
            _screenList.Clear();
            _screenList.Add("0");
            _screenList.Add("0");
            _screenList.Add("0");
            _screenList.Add("0");
            UpdatePublicString();
        }

        #endregion Private methods

        #region Public fields

        /// <summary>
        /// Public accessor and modifier for the screen text
        /// </summary>
        public string Screen
        {
            get { return _screen; }
            set
            {
                _screen = value;
                NotifyOfPropertyChange(() => Screen);
                NotifyOfPropertyChange(() => ButtonsAreEnabled);
                NotifyOfPropertyChange(() => IsUnlocked);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        /// <summary>
        /// Controls the isEnabled property for all the buttons
        /// </summary>
        public bool ButtonsAreEnabled => !Screen.Contains("Wrong!") &&
            !Screen.Contains("Unlocked!") &&
            !Screen.Contains("Enter your new pin and press enter");

        /// <summary>
        /// Accessor and modifier for the isUnlocked property
        /// </summary>
        public bool IsUnlocked
        {
            get { return _isUnlocked; }
            set
            {
                _isUnlocked = value;
                NotifyOfPropertyChange(() => IsUnlocked);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        /// <summary>
        /// Whether the reset button is enabled or not
        /// </summary>
        public bool CanReset => _isUnlocked && !_resetPressed;

        /// <summary>
        /// Accessor and modifier for the passcode
        /// </summary>
        public string Passcode
        {
            get { return _passcode; }
            set
            {
                _passcode = value;
                NotifyOfPropertyChange(() => Passcode);
            }
        }

        #endregion Public fields

        #region Button presses

        #region Number buttons

        /// <summary>
        /// The public event for the One button
        /// </summary>
        public void One()
        {
            UpdatePrivateList();
            AddNewButtonPress("1");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Two button
        /// </summary>
        public void Two()
        {
            UpdatePrivateList();
            AddNewButtonPress("2");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Three button
        /// </summary>
        public void Three()
        {
            UpdatePrivateList();
            AddNewButtonPress("3");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Four button
        /// </summary>
        public void Four()
        {
            UpdatePrivateList();
            AddNewButtonPress("4");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Five button
        /// </summary>
        public void Five()
        {
            UpdatePrivateList();
            AddNewButtonPress("5");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Six button
        /// </summary>
        public void Six()
        {
            UpdatePrivateList();
            AddNewButtonPress("6");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Seven button
        /// </summary>
        public void Seven()
        {
            UpdatePrivateList();
            AddNewButtonPress("7");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Eight button
        /// </summary>
        public void Eight()
        {
            UpdatePrivateList();
            AddNewButtonPress("8");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Nine button
        /// </summary>
        public void Nine()
        {
            UpdatePrivateList();
            AddNewButtonPress("9");
            UpdatePublicString();
        }

        /// <summary>
        /// The public event for the Zero button
        /// </summary>
        public void Zero()
        {
            UpdatePrivateList();
            AddNewButtonPress("0");
            UpdatePublicString();
        }

        #endregion Number buttons

        #region Operation buttons

        /// <summary>
        /// Used to enter the code
        /// </summary>
        public async Task Enter()
        {
            //Checks if the program is unlocked
            //This allowed the code to be changed
            if (IsUnlocked)
            {
                Passcode = Screen;
                IsUnlocked = false;
                Cancel();
                _resetPressed = false;
                return;
            }

            if (_passcode != Screen)
            {
                Screen = "Wrong!";
                await Task.Delay(2000);
                IsUnlocked = false;
                ResetScreen();
            }
            else
            {
                Screen = "Unlocked!";
                IsUnlocked = true;
                //Keep the door open for three seconds before locking again
                await Task.Delay(3000);
                if (!_resetPressed)
                {
                    IsUnlocked = false;
                    ResetScreen();
                }
            }
        }

        /// <summary>
        /// Used to cancel the input and return it to default "0000"
        /// </summary>
        public void Cancel()
        {
            ResetScreen();
            IsUnlocked = false;
        }

        /// <summary>
        /// Used to reset the code to something new
        /// </summary>
        public async Task Reset()
        {
            _resetPressed = true;
            Screen = "Enter your new pin and press enter";
            await Task.Delay(2000);
            ResetScreen();
        }

        #endregion Operation buttons

        #endregion Button presses
    }
}