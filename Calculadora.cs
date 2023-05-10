namespace Calculadora.Winapp
{
    public partial class Calculadora : Form
    {
        public List<String> listaCalculadora;
        public int indiceLista;
        public Calculadora()
        {
            listaCalculadora = new List<String>
            {
                ""
            };
            indiceLista = 0;
            InitializeComponent();
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            switch (botaoClicado.Name)
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
                case "btnComma":
                    AdicionarNumeroNaLista(",");
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
                case "btnDiv":
                    AdicionarOperadorNaLista("/");
                    break;
                case "btnEqual":
                    Calcular();
                    break;
                case "btnDel":
                    RemoverUltimoCaractere();
                    break;
                default:
                    break;
            }
            AtualizarTela();
        }
        public static bool ehOperador(string operador)
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
                indiceLista = listaCalculadora.Count - 1;
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
            indiceLista = listaCalculadora.Count - 1;
        }
        public void RemoverUltimoCaractere()
        {
            if (ehOperador(listaCalculadora[indiceLista]))
            {
                RemoverUltimoLista();
            }
            else
            {
                listaCalculadora[indiceLista] = listaCalculadora[indiceLista][..^1];
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
            
            if (listaCalculadora[0].Length == 0 || listaCalculadora[^1] == "")
            {
                return;
            }
            
            foreach (string item in listaCalculadora)
            {
                if (ehOperador(item))
                {
                    operador = item;
                }
                else
                {
                    switch (operador)
                    {
                        case "+":
                            resultado += Double.Parse(item);
                            break;
                        case "-":
                            resultado -= Double.Parse(item);
                            break;
                        case "*":
                            resultado *= Double.Parse(item);
                            break;
                        case "/":
                            resultado /= Double.Parse(item);
                            break;
                        default:
                            resultado = Double.Parse(item);
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