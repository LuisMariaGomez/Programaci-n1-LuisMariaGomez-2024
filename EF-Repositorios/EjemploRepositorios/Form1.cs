using CEntidades.Entidades;
using CLogica.Contracts;

namespace EjemploRepositorios
{
    public partial class Form1 : Form
    {
        private IAutorLogic _autorLogic;

        public Form1(IAutorLogic autorLogic)
        {
            _autorLogic = autorLogic;
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            List<Autor> autor = await _autorLogic.GetAll();
        }
    }
}
