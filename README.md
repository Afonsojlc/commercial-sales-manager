# 💼 Commercial Sales Manager (SFA)

[![.NET 8](https://img.shields.io/badge/.NET-8.0--windows-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Language C#](https://img.shields.io/badge/Language-C%23_12-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/dotnet/csharp/)
[![UI Blazor WebView](https://img.shields.io/badge/UI-Blazor_WebView_8.0-512BD4?logo=blazor&logoColor=white)](https://learn.microsoft.com/aspnet/core/blazor/hybrid/)
[![Styling Tailwind CSS](https://img.shields.io/badge/Styling-Tailwind_CSS_v3-38B2AC?logo=tailwind-css&logoColor=white)](https://tailwindcss.com/)
[![Database SQL Server](https://img.shields.io/badge/Database-Microsoft_SQL_Server-CC292B?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server/)
[![Architecture SFA](https://img.shields.io/badge/Architecture-Sales_Force_Automation-blue)]()
[![IDE Visual Studio 2022](https://img.shields.io/badge/IDE-Visual_Studio_2022-C8A2C8?logo=visualstudio&logoColor=white)](https://visualstudio.microsoft.com/)
[![License MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

> Enterprise Desktop **Sales Force Automation (SFA)** and B2B Order Management System engineered to eliminate paper order forms and streamline the daily operational workflow of Commercial Directors and field sales representatives in technical distribution and electrical equipment industries.

> [!NOTE]
> **User Interface Localization:** While this technical documentation is in English, the application's user interface is localized in **European Portuguese (pt-PT)** to align directly with B2B commercial practices, tax rules, and regulatory terminology in Portugal.

---

## 📖 Overview & Real-World Business Problem

In technical B2B distribution and electrical equipment wholesale, many sales directors and field representatives still record customer purchase orders manually using physical **carbon copy paper pads**. Once written, orders are traditionally transmitted back to company headquarters by **fax** or by **photographing the paper slip with a smartphone and sending it over email**.

This analog approach introduces severe operational bottlenecks:
* **Transcription Delays & Illegibility:** Order lines and handwritten material references are frequently misread or delayed at the warehouse.
* **Complex Tiered Discount Errors:** Calculating compound cascading manufacturer discounts (e.g. `50+10`, `40+5+2.5`) with a pocket calculator is prone to costly pricing discrepancies.
* **Manual Commission Bookkeeping:** Commercial directors spend hours consolidating handwritten notes to verify monthly sales volumes and earned commissions.
* **Zero Real-Time Stock Visibility:** Field agents cannot verify existing warehouse inventory during client negotiations.

**Commercial Sales Manager** was developed from the ground up as a **real-world production solution** to solve this operational bottleneck:
* **Digital Order Entry in Seconds:** Fast customer lookup by NIF, Company Name, Phone, or City.
* **Automated Cascading Discount Engine:** Exact mathematical computation of multi-tier supplier discounts.
* **Standardized Corporate A4 PDF Documents:** Automatic generation of formal order sheets with corporate headers, itemized breakdowns, client data, and signature confirmation ready for direct email dispatch to headquarters.
* **Real-Time Commission & Performance Tracking:** Instant calculation of sales volume, order counts, and earned commissions per representative.
* **Zero-Downtime Hybrid Operation:** Direct connectivity with the company's central Microsoft SQL Server database, plus a resilient offline demonstration sandbox when operating off-network.

---

## 🏗️ System Architecture

The application adopts a modern **Hybrid Desktop Architecture (.NET 8 + Blazor WebView)**:

```
┌─────────────────────────────────────────────────────────────┐
│               Windows Forms Shell Host                      │
│               (FormMenu.cs hosting BlazorWebView)           │
├─────────────────────────────────────────────────────────────┤
│         Blazor WebView Components (HTML5 / Tailwind CSS)    │
│  ├── Dashboard.razor       ├── Clientes.razor               │
│  ├── NovaVenda.razor       ├── Produtos.razor               │
│  ├── Encomendas.razor      ├── Definicoes.razor             │
│  └── DetalhesEncomenda.razor                                │
├─────────────────────────────────────────────────────────────┤
│                    C# Business Logic Layer                  │
│  ├── Sessao.cs (User Authentication, Roles & Commission)    │
│  ├── ConfiguracaoEmpresa.cs (JSON Company Profile Store)    │
│  └── DatabaseConfig.cs (SQL Discovery & Auto-Fallback)      │
├──────────────────────────────┬──────────────────────────────┤
│    Online Mode (Production)  │   Offline Mode (Demo Sandbox)│
│    Microsoft.Data.SqlClient  │   DadosDemonstracao.cs       │
│    Microsoft SQL Server      │   Thread-Safe In-Memory Repo │
│    DB: CommercialSalesDB     │   Seed Electrical Catalog    │
└──────────────────────────────┴──────────────────────────────┘
```

### Architectural Highlights:
1. **Lightweight Native WinForms Shell:** Boots instantly without the memory footprint of local web servers or Electron runtimes.
2. **Reactive Blazor UI:** Single-page navigation styled with Tailwind CSS utility classes, providing fluid transitions and responsive layouts.
3. **Decoupled Business Logic:** Seller session state, corporate profiles, and database abstraction layers remain decoupled from the visual layer.

---

## 📸 Visual Showcase

*(Screenshots can be placed under `docs/screenshots/` to preview key application modules)*

| Module | Description | Preview |
| :--- | :--- | :---: |
| **Executive Dashboard** | Real-time sales metrics, period revenue, earned commissions, and chronological order history. | `docs/screenshots/dashboard.png` |
| **Order Entry & Discounts** | Fast client lookup, predictive product autocomplete, and multi-tier compound discount formulas (`50+10`). | `docs/screenshots/nova-venda.png` |
| **Corporate A4 Order Note** | Standardized A4 order sheet with company header, client tax dossier, item table, and signature block. | `docs/screenshots/detalhes-encomenda-a4.png` |
| **Sales Team & Roles** | Multi-tab settings panel for enterprise profile, personal credentials, and sales team administration. | `docs/screenshots/definicoes-equipa.png` |

---

## ✨ Key Features

### ⚡ Ergonomic Dual Authentication
* **Dual Login Options:**
  * **Quick 4-digit PIN:** Optimized for touchscreens, field tablets, and high-frequency logins between client site visits.
  * **Email & Password:** Standard corporate login supporting multiple user profiles (*Sales Representative*, *Commercial Director*, *Administrator*).
* **Centralized Session State (`Sessao.cs`):** Retains active seller credentials, role permissions, and contractual commission rates in memory.

### 📦 Material Catalog & Dynamic Stock Management
* **Predictive Product Search:** Real-time keyword filtering across item codes and commercial descriptions.
* **Rapid Stock Adjustments:** Contextual modal allowing immediate stock replenishment or deduction directly from the catalog or sales screens.
* **Item Registration:** Add new items with category/family assignments, base retail prices (PVP), and customizable VAT rates.
* **Role-Based Protection:** Stock updates and catalog alterations restricted to authorized managerial accounts (`Sessao.IsDiretorOuAdmin`).

### 🧮 Compounding Cascading Discount Engine
In electrical distribution and technical B2B trade, supplier discounts are commonly expressed in cascading tiers rather than single flat rates:
$$\text{Effective Unit Price} = \text{PVP} \times (1 - d_1) \times (1 - d_2) \times \dots \times (1 - d_n)$$

* **Supported Notations:** Composed strings such as `50+10`, `40+5+2.5`, or flat percentages (`35%`).
* **Global Order Discount:** Financial closing discount applied over the total transaction balance.
* **Automatic VAT Computation:** Dynamic tax calculation (standard Portuguese 23% or custom rate) with transparent subtotal, tax amount, and final gross total.

### 🛡️ ACID Transactions & Atomic Inventory Abatement
* In SQL Server mode, all finalized orders execute within an atomic `SqlTransaction`:
  1. Creates the header record in `Encomenda`.
  2. Inserts all associated detail lines into `Linha_Encomenda`.
  3. Deducts ordered quantities immediately from `Material` inventory (`Stock = Stock - @Quantity`).
* If any step encounters an exception, the entire transaction triggers a `Rollback()`, preventing orphan orders or inventory corruption.
* **Stock Restoration on Edit/Cancel:** Editing an existing order restores previous stock quantities before applying the updated line adjustments atomically.

### 📄 Corporate A4 Order Documents (Print & PDF)
* High-fidelity order view rendered according to standard European A4 dimensions:
  * Company header with customizable corporate identity (legal name, NIF, registered address, direct contacts).
  * Customer dossier and assigned commercial representative.
  * Itemized table with material codes, descriptions, quantities, base prices, cascading discounts, and line totals.
  * Tax breakdown summary (Net Subtotal, Discounts, Total VAT, Total Payable).
  * Formal stamp and signature confirmation blocks.
* Direct **Print to Physical Printer** and one-click export to **Microsoft Print to PDF** for instant emailing to headquarters.

### 📊 Performance Dashboard & Executive Reporting
* **Real-Time Sales Metrics:**
  * Total revenue billed over the active period (€).
  * Cumulative earned sales commissions (€) computed dynamically from the authenticated user's contractual percentage.
  * Active customer portfolio count.
  * Volume of finalized orders.
* **Flexible Temporal Filters:** Today, Current Month, Current Year, Custom Calendar Date Range, or All-Time.
* **Printable Executive Summary:** Clean A4 report summarizing financial performance and average order value (AOV).
* **Excel Export (CSV):** Instant CSV export formatted for analysis in Microsoft Excel or Google Sheets.

### 🏢 Configurable Enterprise Profile (`empresa_config.json`)
* Built-in Settings screen to manage:
  * Legal Company Name, Business Subtitle, NIF, Address, Postal Code, Phone Number, and Email.
* Changes persist to local JSON storage and immediately update headers on all newly generated order sheets and reports without restarting the application.

---

## 🔄 Operational Workflow

```mermaid
flowchart TD
    A([Application Startup]) --> B[Login: PIN or Email/Password]
    B --> C{Valid Credentials?}
    C -->|Yes| D[Executive Dashboard]
    C -->|No| B

    D --> E[New Order Entry]
    D --> F[Order History & Management]
    D --> G[Customer Directory]
    D --> H[Product Catalog & Stock]
    D --> I[Company & Database Settings]

    E --> E1[Search & Select Customer]
    E1 --> E2[Add Items with Tiered Discounts e.g., 50+10]
    E2 --> E3[Apply Global Discount & Confirm]
    E3 --> E4{Connection Mode?}
    E4 -->|SQL Server| E5[(ACID SqlTransaction: Insert + Abate Stock)]
    E4 -->|Offline Demo| E6[(In-Memory Repo: DadosDemonstracao)]
    E5 --> E7[Redirect to A4 Order Sheet]
    E6 --> E7

    F --> F1[Double-Click Order Row]
    F1 --> F2[View A4 Order Details]
    F2 --> F3[Print / Export to PDF]
    F2 --> F4[Modify Lines or Cancel Order]
```

---

## 🗄️ Relational Database Model (SQL Server)

The database adheres strictly to Third Normal Form (3NF) with enforced foreign keys:

> [!TIP]
> **Architectural Diagrams:**
> * 🖼️ [Conceptual Entity-Relationship Diagram (PNG)](docs/er-diagram.png)
> * 📄 [Relational Model Specification (PDF)](docs/relational-model.pdf)

```mermaid
erDiagram
    VENDEDORES ||--o{ ENCOMENDA : "issues"
    CLIENTES ||--o{ ENCOMENDA : "places"
    ENCOMENDA ||--|{ LINHA_ENCOMENDA : "contains"
    TIPO_PRODUTO ||--|{ MATERIAL : "categorizes"
    MATERIAL ||--o{ LINHA_ENCOMENDA : "composed of"

    VENDEDORES {
        int ID_Vendedor PK "IDENTITY"
        varchar Cargo
        varchar Nome
        varchar PIN
        varchar Email
        varchar Senha
        varchar Telemovel
        decimal Percentagem_Comissao
        bit Ativo
    }

    CLIENTES {
        varchar ID_Cliente PK
        varchar Nome_Cliente
        varchar NIF
        varchar Morada_Completa
        varchar Codigo_Postal
        varchar Cidade
        varchar Email
        varchar Telefone
    }

    TIPO_PRODUTO {
        varchar Id_Produto PK
        varchar Designacao
        varchar Estado
    }

    MATERIAL {
        varchar Codigo PK
        varchar Descricao
        varchar Unidade_Venda
        int Embalagem
        money PVP_Unidade
        int Stock
        varchar ID_Tipo FK
        decimal Taxa_IVA
    }

    ENCOMENDA {
        int Numero_Encomenda PK "IDENTITY"
        date Data_Encomenda
        money Valor_Total
        varchar Estado
        varchar ID_Cliente FK
        int ID_Vendedor FK
        decimal Desconto_Global
    }

    LINHA_ENCOMENDA {
        int NE PK,FK
        int Linha_Encomenda PK
        int Quantidade
        varchar Descricao
        money Preco
        decimal Desconto
        decimal Imposto
        varchar Codigo_Material FK
        varchar Desconto_Texto
    }
```

---

## ⌨️ Ergonomics & Keyboard Shortcuts

Engineered for high-speed order entry without requiring constant mouse reliance:
* <kbd>Enter</kbd> on Code/Description field: automatically adds the item if an exact match is detected.
* <kbd>↑</kbd> / <kbd>↓</kbd> in autocomplete popup: smoothly navigates through suggested product matches.
* <kbd>F2</kbd> (or dedicated button): focuses the product search input immediately.
* **Double-click** on any Order row: opens the official A4 Order Form.
* **Double-click** on any Customer row: instantly initiates a new order for that customer.

---

## 🚀 Setup & Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (v8.0.x or higher)
* [Microsoft SQL Server](https://www.microsoft.com/sql-server/) (Developer, Express, or LocalDB)
* [Visual Studio 2022](https://visualstudio.microsoft.com/) with *.NET Desktop Development* workload (or VS Code with C# Dev Kit)

### 1. Clone the Repository
```bash
git clone https://github.com/Afonsojlc/commercial-sales-manager.git
cd commercial-sales-manager
git checkout feature/new-ui-BlazorWebView
```

### 2. Configure the Database (Optional for Demo Testing)
1. Open [`database_schema.sql`](database/database_schema.sql) in SQL Server Management Studio (SSMS) or Azure Data Studio and execute it to create the `CommercialSalesDB` database and tables.
2. Execute [`database_seed.sql`](database/database_seed.sql) to populate synthetic demonstration material catalog items, clients, and commercial users.
3. Run [`verify_database.sql`](database/verify_database.sql) to verify table structure and record counts.
4. If SQL Server is not running or unreachable, the application automatically boots into **Offline Demonstration Mode**, providing full in-memory functionality without errors.

### 3. Build the Solution
```bash
dotnet build SoftwareVendas/SoftwareVendas.sln
```

### 4. Run the Application
```bash
dotnet run --project SoftwareVendas/SoftwareVendas/SoftwareVendas.csproj
```

### 5. Access Credentials

#### 🟢 Production Mode (Connected to Microsoft SQL Server)
* **Commercial Director (Full Administrative Privileges):**
  * Email: `carlos.silva@eletrodist.pt` | Password: `Paredes10`
  * Quick PIN: `1755`
  * Seller: **Carlos Silva** (Commission: `7.00%`)
* **Sales Representative:**
  * Email: `mariana.santos@eletrodist.pt` | Password: `Paredes11`
  * Quick PIN: `1514`
  * Seller: **Mariana Santos** (Commission: `2.00%`)

#### 🟡 Offline Demonstration Sandbox Mode (No SQL Server Required)
* Automatically activates whenever SQL Server is unreachable, or via the direct **"Entrar em Modo Demonstração (Sandbox)"** button on the Login screen.
* **Demonstration Director Profile:**
  * Representative: **Afonso Carvalho** (Marked with `DEMO` badge)
  * Email: `afonso.carvalho@geral.pt` | Password: `demo` or `admin`
  * Quick PIN: `1234` (or `0000`)
  * Full administrative privileges to explore the system.
  * In-memory isolated storage (`DadosDemonstracao.cs`): test orders, created customers, or stock adjustments are kept in memory and never alter the production SQL database.

---

## 🗺️ Deployment & Engineering Roadmap

As the system moves from operational validation into broader commercial deployment across the sales team, the following infrastructure enhancements are planned:

### 1. 🐳 Containerized Database Deployment (Docker & Docker Compose)
* **Objective:** Enable one-command initialization of the SQL Server environment for branch offices, development environments, and cloud staging.
* **Implementation Plan:**
  * Provide a `docker-compose.yml` leveraging the official `mcr.microsoft.com/mssql/server:2022-latest` image.
  * Embed an initialization entrypoint script that executes `database_schema.sql` and `database_seed.sql` on container startup.
  * Eliminates manual SQL Server Express installations, allowing any machine to boot the backend via:
    ```bash
    docker compose up -d
    ```

### 2. ⚙️ Automated CI/CD Pipeline (Jenkins & GitHub Actions)
* **Objective:** Ensure continuous quality validation, automated regression builds, and seamless packaging upon code push.
* **Implementation Plan:**
  * **Build & Validation:** Automate `dotnet restore` and `dotnet build` with strict error verification.
  * **Test Suite:** Execute automated unit tests for compounding discount calculations and VAT rounding rules.
  * **Automated Publishing:** Run `dotnet publish -c Release -r win-x64 --self-contained true` to produce clean standalone binaries automatically.

### 3. 🚀 Automated Binary Distribution & Release Packaging
* **Objective:** Provide a frictionless delivery mechanism for commercial agents and the sales director without requiring Git or development tooling.
* **Implementation Plan:**
  * Direct publishing of standalone `.exe` release archives (`CommercialSalesManager-vX.Y.Z-win-x64.zip`) through **GitHub Releases** and a dedicated release distribution repository.
  * Inclusion of auto-update checks or automated MSI/InnoSetup desktop installers.

### 4. 📧 Direct 1-Click Headquarters Email Dispatch
* **Objective:** Completely replace faxes and smartphone photos with automated electronic order transmission.
* **Implementation Plan:**
  * Integration of an integrated SMTP/MAPI mailing action directly inside [`DetalhesEncomenda.razor`](file:///c:/Projetos/commercial-sales-manager/SoftwareVendas/SoftwareVendas/Components/Pages/DetalhesEncomenda.razor).
  * With a single click on *"Enviar para a Empresa"*, the generated A4 PDF order sheet is automatically attached and dispatched directly to the central logistics and billing department.

---

## 📁 Repository Structure

```
commercial-sales-manager/
├── database/                            # SQL Server database scripts
│   ├── database_schema.sql              # DDL schema initialization script
│   ├── database_seed.sql                # Synthetic seed data script (materials, clients, sellers)
│   └── verify_database.sql              # Diagnostic queries for SQL Server tables
├── docs/                                # Technical & architectural documentation
│   ├── er-diagram.png                   # Conceptual Entity-Relationship diagram
│   └── relational-model.pdf             # Relational data model specification
├── README.md                            # Comprehensive project documentation
└── SoftwareVendas/
    ├── SoftwareVendas.sln               # Visual Studio 2022 Solution
    └── SoftwareVendas/
        ├── FormMenu.cs                  # WinForms host window embedding BlazorWebView
        ├── DatabaseConfig.cs            # Connection manager with instance auto-discovery
        ├── Sessao.cs                    # Global session holder for authenticated seller & roles
        ├── ConfiguracaoEmpresa.cs       # Company settings profile manager (empresa_config.json)
        ├── DadosDemonstracao.cs         # Thread-safe in-memory mock repository for offline demo
        ├── Components/
        │   ├── App.razor                # Root Blazor component hosting Router and layout
        │   ├── Layout/
        │   │   └── MainLayout.razor     # Collapsible sidebar, top search, and status badges
        │   └── Pages/
        │       ├── Login.razor          # Dual authentication screen (PIN & Email/Password)
        │       ├── Dashboard.razor      # KPIs, commission metrics, reports, and CSV exports
        │       ├── NovaVenda.razor      # Order entry screen with cascading discount logic
        │       ├── Encomendas.razor     # Orders register, statuses, and advanced filtering
        │       ├── DetalhesEncomenda.razor # Formal A4 order view for print and PDF
        │       ├── Clientes.razor       # Customer portfolio management (Director-restricted creation)
        │       ├── Produtos.razor       # Technical product catalog & stock controls
        │       └── Definicoes.razor     # Company profile, user profile & sales team management
        └── wwwroot/
            ├── index.html               # Main HTML entrypoint with Tailwind typography
            └── css/                     # Custom corporate stylesheets and print media rules
```

---

## 👨‍💻 Author & Architecture

**Afonso Carvalho**  
* Software Developer & Systems Architect  
* GitHub: [@Afonsojlc](https://github.com/Afonsojlc)  
