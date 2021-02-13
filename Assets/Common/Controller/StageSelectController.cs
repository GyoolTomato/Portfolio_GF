using System;

namespace Assets.Common.Controller
{
    public class StageSelectController
    {
        int m_selectedStageID;

        public StageSelectController()
        {
        }

        public void Initialize()
        {

        }

        public int SelectedStageID
        {
            get
            {
                return m_selectedStageID;
            }
            set
            {
                m_selectedStageID = value;
            }
        }
    }
}
