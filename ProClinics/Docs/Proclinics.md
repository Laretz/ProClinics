# Projeto Blazor com MudBlazor: ProClinics

## Passo a Passo de Criação

### 1. Criação do Projeto

- **Framework Utilizado**: Blazor com MudBlazor.
- **Objetivo**: Criar um sistema de gestão de clínicas com funcionalidades para médicos, pacientes, recepcionistas e agendamentos.

### 2. Criação dos Models

#### 2.1 Model `Doctor`

- **Atributos**:
  - `Id`
  - `Name`
  - `CPF`
  - `Crm`
  - `Email`
  - `CellPhoneNumber`
  - `RegisterDate`
  - `SpecialtyId`
  - `Speciality` (associação com a classe `Speciality`)
  - `Scheduling` (lista de agendamentos associados ao médico)

#### 2.2 Model `Patient`

- **Atributos**:
  - `Id`
  - `Name`
  - `CPF`
  - `Email`
  - `CellPhoneNumber`
  - `BithDate`
  - `Scheduling` (lista de agendamentos associados ao paciente)

#### 2.3 Model `Receptionist`

- **Herança**: Deriva de `ApplicationUser`.
- **Atributos**:
  - `Name`

#### 2.4 Model `Scheduling`

- **Atributos**:
  - `Id`
  - `Notes`
  - `DoctorId`
  - `PatientId`
  - `AppointmentTime`
  - `AppointmentDate`
  - `Doctor` (associação com a classe `Doctor`)
  - `Patient` (associação com a classe `Patient`)

#### 2.5 Model `Speciality`

- **Atributos**:
  - `Id`
  - `Name`
  - `Description`
  - `Doctors` (lista de médicos associados à especialidade)

### 3. Configuração do Mapeamento com Entity Framework

#### 3.1 Configuração do `Patient`

- **Tabela**: `Patients`
- **Chave Primária**: `Id`
- **Propriedades**:
  - `Name`: Requerido, tipo `VARCHAR(50)`.
  - `CPF`: Requerido, tipo `NVARCHAR(11)`, índice único.
  - `Email`: Requerido, tipo `VARCHAR(50)`.
  - `CellPhoneNumber`: Requerido, tipo `NVARCHAR(11)`.
- **Relacionamento**:
  - **Com `Scheduling`**: Um paciente pode ter muitos agendamentos, com chave estrangeira `PatientId`. Exclusão restrita (`Restrict`).

#### 3.2 Configuração do `Speciality`

- **Tabela**: `Speciality`
- **Chave Primária**: `Id`
- **Propriedades**:
  - `Name`: Requerido, tipo `VARCHAR(30)`.
  - `Description`: Opcional, tipo `VARCHAR(150)`.
- **Relacionamento**:
  - **Com `Doctor`**: Uma especialidade pode ter muitos médicos associados, com exclusão restrita (`Restrict`).

#### 3.3 Configuração do `Doctor`

- **Tabela**: `Doctors`
- **Chave Primária**: `Id`
- **Propriedades**:
  - `Name`: Requerido, tipo `VARCHAR(50)`.
  - `CPF`: Requerido, tipo `VARCHAR(11)`, índice único.
  - `Crm`: Requerido, tipo `VARCHAR(8)`.
  - `CellPhoneNumber`: Requerido, tipo `VARCHAR(1)`.
  - `Speciality`: Requerido.
- **Relacionamento**:
  - **Com `Speciality`**: Um médico está associado a uma especialidade.
  - **Com `Scheduling`**: Um médico pode ter muitos agendamentos, com chave estrangeira `DoctorId`. Exclusão restrita (`Restrict`).

#### 3.4 Configuração do `Scheduling`

- **Tabela**: `Scheduling`
- **Chave Primária**: `Id`
- **Propriedades**:
  - `Notes`: Opcional, tipo `VARCHAR(250)`.
  - `PatientId`: Requerido.
  - `DoctorId`: Requerido.
- **Relacionamento**:
  - **Com `Doctor`**: Um agendamento está associado a um médico.
  - **Com `Patient`**: Um agendamento está associado a um paciente.

### 4. Configuração do Contexto de Dados com Entity Framework

#### 4.1 Configuração do `ApplicationDbContext`

- **Classe**: `ApplicationDbContext`
- **Herança**: Deriva de `IdentityDbContext<ApplicationUser>`.
- **DbSets**:
  - `Specialitys`: Tabela `Speciality`.
  - `Doctors`: Tabela `Doctors`.
  - `Patients`: Tabela `Patients`.
  - `Schedulings`: Tabela `Scheduling`.
- **Método `OnModelCreating`**:
  - Aplica configurações a partir do assembly atual usando `ApplyConfigurationsFromAssembly`.
  - Chama o método base `OnModelCreating` para garantir que as configurações padrão sejam aplicadas.

5. Configuração do Inicializador de Banco de Dados
5.1 Configuração do DbInitializer
Classe: DbInitializer
Construtor: Recebe um ModelBuilder para configuração de dados.
Método seed:
População de IdentityRole:
Adiciona os papéis de "Recepcionist" e "Doctor" com IDs e nomes normalizados.
População de Receptionist:
Adiciona um usuário de recepcionista com email confirmado e senha criptografada.
População de IdentityUserRole:
Associa o usuário criado ao papel de "Recepcionist".
População de Speciality:
Adiciona 10 especialidades com IDs e descrições.
5.2 Configuração do Program.cs
Configuração de Identity:
Adiciona suporte a identidade com AddIdentityCore<ApplicationUser>().
Inclui papéis com AddRoles<IdentityRole>().
Adiciona suporte a gerenciamento de senhas, papéis e autenticação com AddSignInManager(), AddRoleManager<RoleManager<IdentityRole>>(), e AddDefaultTokenProviders().



