using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.SysM
{
    public class CharacterBase : ViewModelBase
    {
        #region 选中
        private WMS_Character_Model selectedCharacter;

        public WMS_Character_Model SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                selectedCharacter = value;
                OnPropertyChanged("SelectedCharacter");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Character_Model> characterList;

        public ObservableCollection<WMS_Character_Model> CharacterList
        {
            get
            {
                if (characterList == null)
                {
                    characterList = new ObservableCollection<WMS_Character_Model>();
                }
                return characterList;
            }
            set
            {
                characterList = value;
                OnPropertyChanged("CharacterList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayCharacterList;

        public bool DisplayCharacterList
        {
            get { return displayCharacterList; }
            set
            {
                displayCharacterList = value;
                OnPropertyChanged("DisplayCharacterList");
            }
        }

        public void ShowCharacterList(bool show = true)
        {
            if (CharacterList.Count > 0)
            {
                DisplayCharacterList = show;
            }
            else
            {
                DisplayCharacterList = false;
            }
        }
        #endregion
    }
}
