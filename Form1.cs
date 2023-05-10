namespace Calculadora.Winapp
{
    public partial class Calculadora : Form
    {
        public List<String> listaCalculadora;
        public int indiceLista;
        public Calculadora()
        {
            listaCalculadora = new List<String>();
            listaCalculadora.Add("");
            indiceLista = 0;
            InitializeComponent();
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            string nomeBotao = botaoClicado.Name;

            switch (nomeBotao)
            {
                case "btnZero":
                    AdicionarNumeroNaLista("0");
                    break;
                case "btnOne":
                    AdicionarNumeroNaLista("1");
                    break;
                case "btnTwo":
                    AdicionarNumeroNaLista("2");
                    break;
                case "btnThree":
                    AdicionarNumeroNaLista("3");
                    break;
                case "btnFour":
                    AdicionarNumeroNaLista("4");
                    break;
                case "btnFive":
                    AdicionarNumeroNaLista("5");
                    break;
                case "btnSix":
                    AdicionarNumeroNaLista("6");
                    break;
                case "btnSeven":
                    AdicionarNumeroNaLista("7");
                    break;
                case "btnEight":
                    AdicionarNumeroNaLista("8");
                    break;
                case "btnNine":
                    AdicionarNumeroNaLista("9");
                    break;
                case "btnPlus":
                    AdicionarOperadorNaLista("+");
                    break;
                case "btnMinus":
                    AdicionarOperadorNaLista("-");
                    break;
                case "btnMul":
                    AdicionarOperadorNaLista("*");
                    break;
                case "btnDivide":
                    AdicionarOperadorNaLista("/");
                    break;
                case "btnEqual":
                    Calcular();
                    break;
                case "btnDel":
                    RemoverUltimoCaractere();
                    break;
            }
            AtualizarTela();
        }
        public bool ehOperador(string operador)
        {
            return operador.Contains("+") || operador.Contains("-") || operador.Contains("*") || operador.Contains("/");
        }
        public void AdicionarOperadorNaLista(string operador)
        {
            if (ehOperador(listaCalculadora[indiceLista]))
            {
                RemoverUltimoCaractere();
                listaCalculadora.Sort();
            }
            if (listaCalculadora[indiceLista] != "")
            {
                listaCalculadora.Add(operador);
                listaCalculadora.Add("");
                this.indiceLista = listaCalculadora.Count - 1;
            }
        }
        public void AdicionarNumeroNaLista(string numero)
        {
            listaCalculadora[indiceLista] += numero;
        }
        public void RemoverUltimoLista()
        {
            listaCalculadora.RemoveAt(listaCalculadora.Count - 1);
            listaCalculadora.Sort();
            this.indiceLista = listaCalculadora.Count - 1;
        }
        public void RemoverUltimoCaractere()
        {
            if (ehOperador(listaCalculadora[indiceLista]))
            {
                RemoverUltimoLista();
            }
            else
            {
                listaCalculadora[indiceLista] = listaCalculadora[indiceLista].Substring(0, listaCalculadora[indiceLista].Length - 1);
            }
        }
        public void AtualizarTela()
        {
            string texto = "";
            foreach (string item in listaCalculadora)
            {
                texto += item;
            }
            rtbTela.Text = texto;
        }
        public void Calcular()
        {
            double resultado = 0;
            string operador = "";
            foreach (string item in listaCalculadora)
            {
                if (ehOperador(item))
                {
                    operador = item;
                    continue;
                }
                else
                {
                    switch (operador)
                    {
                        case "+":
                            resultado += Convert.ToDouble(item);
                            break;
                        case "-":
                            resultado -= Convert.ToDouble(item);
                            break;
                        case "*":
                            resultado *= Convert.ToDouble(item);
                            break;
                        case "/":
                            resultado /= Convert.ToDouble(item);
                            break;
                        default:
                            resultado = Convert.ToDouble(item);
                            break;
                    }
                }
            }
            listaCalculadora.Clear();
            listaCalculadora.Add(resultado.ToString());
            indiceLista = 0;
        }
    }
}