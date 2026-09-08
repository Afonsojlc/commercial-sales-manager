using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SoftwareVendas
{
    /// <summary>
    /// In-memory mock data store for offline demonstration and testing.
    /// </summary>
    public static class DadosDemonstracao
    {
        #region Data Models

        public class ClienteDemo
        {
            public string ID_Cliente { get; set; } = "";
            public string Nome_Cliente { get; set; } = "";
            public string NIF { get; set; } = "";
            public string Morada_Completa { get; set; } = "";
            public string Codigo_Postal { get; set; } = "";
            public string Cidade { get; set; } = "";
            public string Email { get; set; } = "";
            public string Telefone { get; set; } = "";
        }

        public class ArtigoDemo
        {
            public string Codigo { get; set; } = "";
            public string Descricao { get; set; } = "";
            public string Unidade_Venda { get; set; } = "UN";
            public int Embalagem { get; set; } = 1;
            public decimal PVP_Unidade { get; set; }
            public int Stock { get; set; }
            public decimal Taxa_IVA { get; set; } = 23m;
            public string ID_Tipo { get; set; } = "MAT";
        }

        public class LinhaDemo
        {
            public int LinhaNum { get; set; }
            public string Codigo { get; set; } = "";
            public string Descricao { get; set; } = "";
            public int Quantidade { get; set; }
            public decimal PrecoUnitario { get; set; }
            public decimal TaxaIva { get; set; } = 23m;
            public string DescontoTexto { get; set; } = "";
            public decimal PrecoComDesconto { get; set; }
            public decimal TotalLinha => Quantidade * PrecoComDesconto * (1 + TaxaIva / 100m);
        }

        public class EncomendaDemo
        {
            public int Numero_Encomenda { get; set; }
            public DateTime Data_Encomenda { get; set; }
            public decimal Valor_Total { get; set; }
            public decimal Desconto_Global { get; set; }
            public string Estado { get; set; } = "PENDENTE";
            public string ID_Cliente { get; set; } = "";
            public string NomeCliente { get; set; } = "";
            public string NIFCliente { get; set; } = "";
            public string MoradaCliente { get; set; } = "";
            public string EmailCliente { get; set; } = "";
            public string TelefoneCliente { get; set; } = "";
            public int ID_Vendedor { get; set; } = 1;
            public string NomeVendedor { get; set; } = "Afonso Carvalho";
            public List<LinhaDemo> Linhas { get; set; } = new List<LinhaDemo>();
        }

        public class VendedorDemo
        {
            public int ID_Vendedor { get; set; }
            public string Nome { get; set; } = "";
            public string Cargo { get; set; } = "Vendedor";
            public string PIN { get; set; } = "1234";
            public string Email { get; set; } = "";
            public string Senha { get; set; } = "";
            public string Telemovel { get; set; } = "";
            public decimal Percentagem_Comissao { get; set; } = 5.0m;
            public bool Ativo { get; set; } = true;
        }

        #endregion

        #region In-Memory Storage

        private static readonly List<ClienteDemo> _clientes = new List<ClienteDemo>();
        private static readonly List<ArtigoDemo> _artigos = new List<ArtigoDemo>();
        private static readonly List<EncomendaDemo> _encomendas = new List<EncomendaDemo>();
        private static readonly List<VendedorDemo> _vendedores = new List<VendedorDemo>();
        private static int _proximoNumeroEncomenda = 1005;
        private static bool _inicializado = false;

        #endregion

        #region Initialization & Seed Data

        static DadosDemonstracao()
        {
            InicializarDados();
        }

        public static void InicializarDados()
        {
            if (_inicializado) return;

            // Seed clients
            _clientes.AddRange(new[]
            {
                new ClienteDemo { ID_Cliente = "CLI-001", Nome_Cliente = "ElectroLuz Porto Lda", NIF = "501234567", Morada_Completa = "Rua de Santa Catarina, 120", Codigo_Postal = "4000-447", Cidade = "Porto", Email = "compras@electroluz.pt", Telefone = "220123456" },
                new ClienteDemo { ID_Cliente = "CLI-002", Nome_Cliente = "Instalações Elétricas Silva & Filhos", NIF = "508765432", Morada_Completa = "Avenida Central, 45", Codigo_Postal = "4700-322", Cidade = "Braga", Email = "geral@silvaelectricos.pt", Telefone = "253987654" },
                new ClienteDemo { ID_Cliente = "CLI-003", Nome_Cliente = "VoltMinho Engenharia & Quadros Lda", NIF = "509876541", Morada_Completa = "Parque Industrial de Coelima", Codigo_Postal = "4835-502", Cidade = "Guimarães", Email = "engenharia@voltminho.pt", Telefone = "253456789" },
                new ClienteDemo { ID_Cliente = "CLI-004", Nome_Cliente = "Central Norte Eletricidade Unipessoal", NIF = "504321987", Morada_Completa = "Zona Industrial de Gaia, Lote 12", Codigo_Postal = "4400-010", Cidade = "Vila Nova de Gaia", Email = "obras@centralnorte.pt", Telefone = "223789456" },
                new ClienteDemo { ID_Cliente = "CLI-005", Nome_Cliente = "Iluminação & Projetos Ribatejo Lda", NIF = "502987123", Morada_Completa = "Estrada Nacional 3, Km 14", Codigo_Postal = "2000-112", Cidade = "Santarém", Email = "comercial@iluribatejo.pt", Telefone = "243123789" }
            });

            // Seed catalog items
            _artigos.AddRange(new[]
            {
                new ArtigoDemo { Codigo = "CAB-001", Descricao = "Cabo H07V-U 1.5mm² Preto (Rolo 100m)", Unidade_Venda = "RL", Embalagem = 1, PVP_Unidade = 24.50m, Stock = 140, Taxa_IVA = 23m, ID_Tipo = "CAB" },
                new ArtigoDemo { Codigo = "CAB-002", Descricao = "Cabo H07V-U 2.5mm² Azul (Rolo 100m)", Unidade_Venda = "RL", Embalagem = 1, PVP_Unidade = 38.90m, Stock = 85, Taxa_IVA = 23m, ID_Tipo = "CAB" },
                new ArtigoDemo { Codigo = "CAB-003", Descricao = "Cabo XV 3G1.5mm² Cinzento (Metro)", Unidade_Venda = "M", Embalagem = 50, PVP_Unidade = 1.15m, Stock = 450, Taxa_IVA = 23m, ID_Tipo = "CAB" },
                new ArtigoDemo { Codigo = "DIS-016", Descricao = "Disjuntor Magnetotérmico 1P+N 16A Curva C Schneider", Unidade_Venda = "UN", Embalagem = 12, PVP_Unidade = 6.80m, Stock = 210, Taxa_IVA = 23m, ID_Tipo = "DIS" },
                new ArtigoDemo { Codigo = "DIS-020", Descricao = "Disjuntor Magnetotérmico 1P+N 20A Curva C Hager", Unidade_Venda = "UN", Embalagem = 12, PVP_Unidade = 7.20m, Stock = 95, Taxa_IVA = 23m, ID_Tipo = "DIS" },
                new ArtigoDemo { Codigo = "DIF-040", Descricao = "Interruptor Diferencial 2P 40A 30mA AC Legrand", Unidade_Venda = "UN", Embalagem = 1, PVP_Unidade = 34.50m, Stock = 42, Taxa_IVA = 23m, ID_Tipo = "DIF" },
                new ArtigoDemo { Codigo = "TUB-020", Descricao = "Tubo Corrugado VD 20mm c/ Guia (Rolo 100m)", Unidade_Venda = "RL", Embalagem = 1, PVP_Unidade = 19.80m, Stock = 60, Taxa_IVA = 23m, ID_Tipo = "TUB" },
                new ArtigoDemo { Codigo = "PRO-LED", Descricao = "Projetor LED Exterior 50W 4000K IP65 Preto", Unidade_Venda = "UN", Embalagem = 1, PVP_Unidade = 22.00m, Stock = 35, Taxa_IVA = 23m, ID_Tipo = "ILU" },
                new ArtigoDemo { Codigo = "TOM-001", Descricao = "Tomada Schuko 2P+T 16A Branca c/ Obturador", Unidade_Venda = "UN", Embalagem = 20, PVP_Unidade = 3.20m, Stock = 180, Taxa_IVA = 23m, ID_Tipo = "APA" }
            });

            // Seed sample orders
            var enc1 = new EncomendaDemo
            {
                Numero_Encomenda = 1001,
                Data_Encomenda = DateTime.Today.AddDays(-2),
                Estado = "FECHADA",
                ID_Cliente = "CLI-001",
                NomeCliente = "ElectroLuz Porto Lda",
                NIFCliente = "501234567",
                MoradaCliente = "Rua de Santa Catarina, 120 - Porto",
                EmailCliente = "compras@electroluz.pt",
                TelefoneCliente = "220123456",
                Desconto_Global = 15.00m,
                Linhas = new List<LinhaDemo>
                {
                    new LinhaDemo { LinhaNum = 1, Codigo = "CAB-001", Descricao = "Cabo H07V-U 1.5mm² Preto (Rolo 100m)", Quantidade = 5, PrecoUnitario = 24.50m, DescontoTexto = "20", PrecoComDesconto = 19.60m, TaxaIva = 23m },
                    new LinhaDemo { LinhaNum = 2, Codigo = "DIS-016", Descricao = "Disjuntor Magnetotérmico 1P+N 16A Curva C Schneider", Quantidade = 20, PrecoUnitario = 6.80m, DescontoTexto = "15+5", PrecoComDesconto = 5.49m, TaxaIva = 23m }
                }
            };
            enc1.Valor_Total = Math.Round(enc1.Linhas.Sum(l => l.TotalLinha) - enc1.Desconto_Global, 2);

            var enc2 = new EncomendaDemo
            {
                Numero_Encomenda = 1002,
                Data_Encomenda = DateTime.Today.AddDays(-1),
                Estado = "PENDENTE",
                ID_Cliente = "CLI-002",
                NomeCliente = "Instalações Elétricas Silva & Filhos",
                NIFCliente = "508765432",
                MoradaCliente = "Avenida Central, 45 - Braga",
                EmailCliente = "geral@silvaelectricos.pt",
                TelefoneCliente = "253987654",
                Desconto_Global = 0,
                Linhas = new List<LinhaDemo>
                {
                    new LinhaDemo { LinhaNum = 1, Codigo = "DIF-040", Descricao = "Interruptor Diferencial 2P 40A 30mA AC Legrand", Quantidade = 4, PrecoUnitario = 34.50m, DescontoTexto = "10", PrecoComDesconto = 31.05m, TaxaIva = 23m },
                    new LinhaDemo { LinhaNum = 2, Codigo = "TUB-020", Descricao = "Tubo Corrugado VD 20mm c/ Guia (Rolo 100m)", Quantidade = 3, PrecoUnitario = 19.80m, DescontoTexto = "25", PrecoComDesconto = 14.85m, TaxaIva = 23m }
                }
            };
            enc2.Valor_Total = Math.Round(enc2.Linhas.Sum(l => l.TotalLinha), 2);

            var enc3 = new EncomendaDemo
            {
                Numero_Encomenda = 1003,
                Data_Encomenda = DateTime.Today,
                Estado = "FECHADA",
                ID_Cliente = "CLI-003",
                NomeCliente = "VoltMinho Engenharia & Quadros Lda",
                NIFCliente = "509876541",
                MoradaCliente = "Parque Industrial de Coelima - Guimarães",
                EmailCliente = "engenharia@voltminho.pt",
                TelefoneCliente = "253456789",
                Desconto_Global = 25.00m,
                Linhas = new List<LinhaDemo>
                {
                    new LinhaDemo { LinhaNum = 1, Codigo = "PRO-LED", Descricao = "Projetor LED Exterior 50W 4000K IP65 Preto", Quantidade = 10, PrecoUnitario = 22.00m, DescontoTexto = "30", PrecoComDesconto = 15.40m, TaxaIva = 23m }
                }
            };
            enc3.Valor_Total = Math.Round(enc3.Linhas.Sum(l => l.TotalLinha) - enc3.Desconto_Global, 2);

            var enc4 = new EncomendaDemo
            {
                Numero_Encomenda = 1004,
                Data_Encomenda = DateTime.Today,
                Estado = "PENDENTE",
                ID_Cliente = "CLI-004",
                NomeCliente = "Central Norte Eletricidade Unipessoal",
                NIFCliente = "504321987",
                MoradaCliente = "Zona Industrial de Gaia, Lote 12",
                EmailCliente = "obras@centralnorte.pt",
                TelefoneCliente = "223789456",
                Desconto_Global = 0,
                Linhas = new List<LinhaDemo>
                {
                    new LinhaDemo { LinhaNum = 1, Codigo = "CAB-002", Descricao = "Cabo H07V-U 2.5mm² Azul (Rolo 100m)", Quantidade = 4, PrecoUnitario = 38.90m, DescontoTexto = "15", PrecoComDesconto = 33.06m, TaxaIva = 23m }
                }
            };
            _encomendas.AddRange(new[] { enc1, enc2, enc3, enc4 });

            // Seed sellers (fictional model commercial team + demo administrator)
            _vendedores.AddRange(new[]
            {
                new VendedorDemo { ID_Vendedor = 999, Nome = "Afonso Carvalho", Cargo = "DEMO (Diretor Comercial)", PIN = "1234", Email = "afonso.carvalho@geral.pt", Senha = "demo", Telemovel = "912345678", Percentagem_Comissao = 5.00m, Ativo = true },
                new VendedorDemo { ID_Vendedor = 101, Nome = "Carlos Silva", Cargo = "Director Comercial", PIN = "1755", Email = "carlos.silva@eletrodist.pt", Senha = "demo", Telemovel = "910000001", Percentagem_Comissao = 7.00m, Ativo = true },
                new VendedorDemo { ID_Vendedor = 102, Nome = "Mariana Santos", Cargo = "Comercial de Vendas", PIN = "1514", Email = "mariana.santos@eletrodist.pt", Senha = "demo", Telemovel = "910000002", Percentagem_Comissao = 2.00m, Ativo = true }
            });

            _inicializado = true;
        }

        #endregion

        #region Customer Operations

        public static List<ClienteDemo> ObterClientes(string termo = "")
        {
            if (string.IsNullOrWhiteSpace(termo)) return _clientes.ToList();
            string t = termo.Trim().ToLowerInvariant();
            return _clientes.Where(c => c.Nome_Cliente.ToLowerInvariant().Contains(t) ||
                                        c.NIF.Contains(t) ||
                                        c.Cidade.ToLowerInvariant().Contains(t) ||
                                        c.Email.ToLowerInvariant().Contains(t) ||
                                        c.ID_Cliente.ToLowerInvariant().Contains(t)).ToList();
        }

        public static ClienteDemo? ObterClientePorId(string id)
        {
            return _clientes.FirstOrDefault(c => c.ID_Cliente.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public static void AdicionarCliente(ClienteDemo cliente)
        {
            _clientes.RemoveAll(c => c.ID_Cliente.Equals(cliente.ID_Cliente, StringComparison.OrdinalIgnoreCase));
            _clientes.Add(cliente);
        }

        #endregion

        #region Product & Stock Operations

        public static List<ArtigoDemo> ObterArtigos(string termo = "")
        {
            if (string.IsNullOrWhiteSpace(termo)) return _artigos.ToList();
            string t = termo.Trim().ToLowerInvariant();
            return _artigos.Where(a => a.Codigo.ToLowerInvariant().Contains(t) ||
                                       a.Descricao.ToLowerInvariant().Contains(t)).ToList();
        }

        public static ArtigoDemo? ObterArtigoPorCodigo(string codigo)
        {
            return _artigos.FirstOrDefault(a => a.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        public static void AtualizarStockArtigo(string codigo, int delta)
        {
            var art = ObterArtigoPorCodigo(codigo);
            if (art != null)
            {
                art.Stock += delta;
            }
        }

        public static void AdicionarArtigo(ArtigoDemo artigo)
        {
            _artigos.RemoveAll(a => a.Codigo.Equals(artigo.Codigo, StringComparison.OrdinalIgnoreCase));
            _artigos.Add(artigo);
        }

        public static void ApagarArtigo(string codigo)
        {
            _artigos.RemoveAll(a => a.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        #region Order Operations

        public static List<EncomendaDemo> ObterEncomendas(string filtro = "", DateTime? dInicio = null, DateTime? dFim = null)
        {
            var query = _encomendas.AsEnumerable();

            if (dInicio.HasValue)
            {
                query = query.Where(e => e.Data_Encomenda.Date >= dInicio.Value.Date);
            }
            if (dFim.HasValue)
            {
                query = query.Where(e => e.Data_Encomenda.Date <= dFim.Value.Date);
            }
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                string f = filtro.Trim().ToLowerInvariant();
                query = query.Where(e => e.Numero_Encomenda.ToString().Contains(f) ||
                                         e.NomeCliente.ToLowerInvariant().Contains(f) ||
                                         e.NomeVendedor.ToLowerInvariant().Contains(f) ||
                                         e.Estado.ToLowerInvariant().Contains(f));
            }

            return query.OrderByDescending(e => e.Numero_Encomenda).ToList();
        }

        public static EncomendaDemo? ObterEncomendaPorId(int id)
        {
            return _encomendas.FirstOrDefault(e => e.Numero_Encomenda == id);
        }

        public static void AtualizarEstadoEncomenda(int id, string novoEstado)
        {
            var enc = ObterEncomendaPorId(id);
            if (enc != null)
            {
                enc.Estado = novoEstado;
            }
        }

        public static int SalvarEncomenda(
            ClienteDemo cliente,
            List<LinhaDemo> linhas,
            decimal descontoGlobal,
            int? idEditar = null)
        {
            int numero;

            if (idEditar.HasValue && idEditar.Value > 0)
            {
                numero = idEditar.Value;
                var existente = ObterEncomendaPorId(numero);
                if (existente != null)
                {
                    // Revert previous inventory deductions
                    foreach (var l in existente.Linhas)
                    {
                        AtualizarStockArtigo(l.Codigo, l.Quantidade);
                    }
                    _encomendas.Remove(existente);
                }
            }
            else
            {
                numero = _proximoNumeroEncomenda++;
            }

            // Deduct current ordered quantities from stock
            foreach (var l in linhas)
            {
                AtualizarStockArtigo(l.Codigo, -l.Quantidade);
            }

            decimal subtotalComIva = linhas.Sum(l => l.TotalLinha);
            decimal valorTotalFinal = Math.Max(0, subtotalComIva - descontoGlobal);

            var novaEnc = new EncomendaDemo
            {
                Numero_Encomenda = numero,
                Data_Encomenda = DateTime.Now,
                Valor_Total = Math.Round(valorTotalFinal, 2),
                Desconto_Global = Math.Round(descontoGlobal, 2),
                Estado = "PENDENTE",
                ID_Cliente = cliente.ID_Cliente,
                NomeCliente = cliente.Nome_Cliente,
                NIFCliente = cliente.NIF,
                MoradaCliente = cliente.Morada_Completa,
                EmailCliente = cliente.Email,
                TelefoneCliente = cliente.Telefone,
                ID_Vendedor = Sessao.ID_Vendedor > 0 ? Sessao.ID_Vendedor : 1,
                NomeVendedor = !string.IsNullOrEmpty(Sessao.Nome) ? Sessao.Nome : "Afonso Carvalho",
                Linhas = new List<LinhaDemo>(linhas)
            };

            _encomendas.Insert(0, novaEnc);
            return numero;
        }

        #endregion

        #region Seller Operations

        public static List<VendedorDemo> ObterVendedores()
        {
            return _vendedores.ToList();
        }

        public static void SalvarVendedor(VendedorDemo vendedor)
        {
            if (vendedor.ID_Vendedor <= 0)
            {
                vendedor.ID_Vendedor = _vendedores.Count > 0 ? _vendedores.Max(v => v.ID_Vendedor) + 1 : 1;
                _vendedores.Add(vendedor);
            }
            else
            {
                int idx = _vendedores.FindIndex(v => v.ID_Vendedor == vendedor.ID_Vendedor);
                if (idx >= 0)
                {
                    _vendedores[idx] = vendedor;
                }
                else
                {
                    _vendedores.Add(vendedor);
                }
            }
        }

        public static void ApagarVendedor(int id)
        {
            _vendedores.RemoveAll(v => v.ID_Vendedor == id);
        }

        #endregion
    }
}
