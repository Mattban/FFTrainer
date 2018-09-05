using FFTrainer.Models;
using FFTrainer.Util;

namespace FFTrainer.ViewModels
{
    public class BaseViewModel
    {
        public static BaseModel model;
        protected Mediator mediator;

        public BaseViewModel(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
