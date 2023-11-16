using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeiD_.ViewModel
{
    // ViewModel básico
    public class FeedViewModel : BindableObject
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        // Constructor (pode conter lógica de inicialização)
        public FeedViewModel()
        {
            // Pode inicializar UserName com um valor padrão se necessário
            UserName = App.Usuario.NomeUsuario;
        }
    }
}
