using KarveCommonInterfaces;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace AssistTestApp
{
    /// <summary>
    ///  BaseDto.
    /// </summary>
    public class NameDto
    {
        /// <summary>
        ///  Name 
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        ///  Surname
        /// </summary>
        public string Surname { set; get; }
    }
    /// <summary>
    ///  AssistTestViewModel.
    /// </summary>
    public class AssistTestViewModel: BindableBase, IAssistViewModel
    {
        private ICommand _command;
        private IAssistService _service;
        /// <summary>
        ///  AssistTestViewModel command.
        /// </summary>
        public AssistTestViewModel(IAssistService service)
        {
            _command = new DelegateCommand<object>(OnAssistShowView);
            _service = service;   
        }
        private void OnAssistShowView(object obj)
        {
            List<NameDto> names = new List<NameDto>()
            {
                new NameDto { Name="Giorgio", Surname="Zoppi"},
                new NameDto { Name ="Carlos", Surname="Velasco"}
            };
            _service.ShowAssistView<NameDto>("Trial", names);
            var item = _service.SelectedItem;

        }
        /// <summary>
        /// Command is a command for launching the test assist.
        /// </summary>
        public ICommand Command
        {
            set
            {
               _command = value;
                RaisePropertyChanged();
            }
            get
            {
                return _command;
            }
        }

    }
}
