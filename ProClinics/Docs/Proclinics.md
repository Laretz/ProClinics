# Projeto Blazor com MudBlazor: ProClinics

## Passo a Passo de Criação

### 1. Criação do Projeto

- **Framework Utilizado**: Blazor com MudBlazor.
- **Objetivo**: Criar um sistema de gestão de clínicas com funcionalidades para médicos, pacientes, recepcionistas e agendamentos.
## 2. Criação dos Models

### 2.1 Model Doctor
* **Atributos:**
    * Id (int) - Identificador único do médico
    * Name (string) - Nome completo do médico
    * CPF (string) - Número de CPF do médico
    * Crm (string) - Número de registro do CRM
    * Email (string) - Endereço de email
    * CellPhoneNumber (string) - Número de telefone celular
    * RegisterDate (DateTime) - Data de registro
    * SpecialtyId (int) - Identificador da especialidade
    * Speciality (Speciality) - Objeto da especialidade associada ao médico (relacionamento de navegação)
    * Scheduling (List<Scheduling>) - Lista de agendamentos associados ao médico

#### 2.2 Model Patient
* **Atributos:**
    * Id (int) - Identificador único do paciente
    * Name (string) - Nome completo do paciente
    * CPF (string) - Número de CPF do paciente
    * Email (string) - Endereço de email
    * CellPhoneNumber (string) - Número de telefone celular
    * BithDate (DateTime) - Data de nascimento
    * Scheduling (List<Scheduling>) - Lista de agendamentos associados ao paciente

#### 2.3 Model Receptionist
* **Herança:** Deriva de ApplicationUser.
* **Atributos:**
    * Name (string) - Nome completo do recepcionista

#### 2.4 Model Scheduling
* **Atributos:**
    * Id (int) - Identificador único do agendamento
    * Notes (string) - Observações sobre o agendamento
    * DoctorId (int) - Identificador do médico
    * PatientId (int) - Identificador do paciente
    * AppointmentTime (DateTime) - Horário do agendamento
    * AppointmentDate (DateTime) - Data do agendamento
    * Doctor (Doctor) - Objeto do médico associado ao agendamento (relacionamento de navegação)
    * Patient (Patient) - Objeto do paciente associado ao agendamento (relacionamento de navegação)

#### 2.5 Model Speciality
* **Atributos:**
    * Id (int) - Identificador único da especialidade
    * Name (string) - Nome da especialidade
    * Description (string) - Descrição da especialidade
    * Doctors (List<Doctor>) - Lista de médicos associados à especialidade

## 3. Configuração do Mapeamento com Entity Framework

## 3.1 Configuração da Entidade Patient

* **Tabela:** Patients
* **Chave Primária:** Id
* **Propriedades:**
    * Name: Requerido, VARCHAR(50)
    * CPF: Requerido, NVARCHAR(11), índice único (evita duplicidade de cadastros)
    * Email: Requerido, VARCHAR(50)
    * CellPhoneNumber: Requerido, NVARCHAR(11)
* **Relacionamentos:**
    * Um paciente pode ter muitos agendamentos (Restrict)
## 3.2 Configuração da Entidade Speciality
* **Tabela:** Speciality
* **Chave Primária:** Id
* **Propriedades:**
    * Name: Requerido, VARCHAR(30), representa o nome da especialidade médica.
    * Description: Opcional, VARCHAR(150), permite descrever a especialidade com mais detalhes.
* **Relacionamentos:**
    * Uma especialidade pode ter muitos médicos (Restrict)

## 3.3 Configuração da Entidade Doctor

* **Tabela:** Doctors
* **Chave Primária:** Id
* **Propriedades:**
    * Name: Requerido, VARCHAR(50)
    * CPF: Requerido, VARCHAR(11), índice único (evita duplicidade de cadastros)
    * Crm: Requerido, VARCHAR(8)
    * CellPhoneNumber: Requerido, VARCHAR(11)
    * Speciality: Requerido (relacionamento navegacional para a entidade Speciality)
* **Relacionamentos:**
    * Um médico está associado a uma especialidade (chave estrangeira: SpecialityId - int)
    * Um médico pode ter muitos agendamentos (Restrict)
* **Propriedades de Navegação:**
    * Speciality: Permite acessar a especialidade associada a um médico.
    * Scheduling: Permite acessar a lista de agendamentos associados a um médico.

## 3.4 Configuração da Entidade Scheduling

* **Tabela:** Scheduling
* **Chave Primária:** Id
* **Propriedades:**
    * Notes: Opcional, VARCHAR(250) para anotações sobre o agendamento.
    * PatientId: Requerido, chave estrangeira para a tabela Patients, estabelecendo a relação com o paciente.
    * DoctorId: Requerido, chave estrangeira para a tabela Doctors, estabelecendo a relação com o médico.
    * SchedulingDate: Requerido, DATETIME, indicando a data e hora do agendamento.
    * Status: Requerido, VARCHAR(20), indicando o status do agendamento (agendado, realizado, cancelado).
* **Relacionamentos:**
    * Um agendamento pertence a um único paciente (chave estrangeira PatientId).
    * Um agendamento pertence a um único médico (chave estrangeira DoctorId).
    * Um paciente pode ter muitos agendamentos.
    * Um médico pode ter muitos agendamentos.
* **Índices:**
    * Índice composto em PatientId e SchedulingDate para otimizar consultas por paciente e data.
* **Observações:**
    * Considerar a adição de um campo para o horário de início e fim do agendamento, caso necessário.
    * Implementar validações para garantir que a data do agendamento seja futura.

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

5. . Configuração do Inicializador de Banco de Dados
5.1 Configuração do DbInitializer
Classe: DbInitializer
Construtor: Recebe um ModelBuilder para configuração de dados.
Método Seed:
População de IdentityRole:
Adiciona os papéis de "Recepcionist" e "Doctor" com IDs e nomes normalizados. Estes papéis são utilizados para controle de acesso e permissões no sistema.
População de Receptionist:
Adiciona um usuário de recepcionista com email confirmado e senha criptografada. O usuário é configurado com o papel de "Recepcionist".
População de IdentityUserRole:
Associa o usuário criado ao papel de "Recepcionist", permitindo que ele tenha as permissões associadas a esse papel.
População de Speciality:
Adiciona 10 especialidades médicas com IDs e descrições. Isso facilita o início do sistema com dados relevantes para as especialidades.
5.2 Configuração do Program.cs
Configuração de Identity:
Métodos Utilizados:
AddIdentityCore<ApplicationUser>(): Adiciona suporte à identidade básica para o usuário.
AddRoles<IdentityRole>(): Inclui suporte a papéis de identidade.
AddSignInManager(): Adiciona suporte para gerenciamento de login.
AddRoleManager<RoleManager<IdentityRole>>(): Adiciona suporte ao gerenciamento de papéis.
AddDefaultTokenProviders(): Configura provedores de tokens padrão para operações de identidade, como recuperação de senha e verificação de email.
5.3 Configuração da Connection String
Connection String:
Localização: Configurada no arquivo appsettings.json.
Formato:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ProClinicsDb;User Id=your_user_id;Password=your_password;"
}
Detalhes:
Server: Endereço do servidor de banco de dados (ex.: localhost para banco local).
Database: Nome do banco de dados (ex.: ProClinicsDb).
User Id: Identificador do usuário para conexão.
Password: Senha do usuário para conexão.


### 6. Executando o SQL Server no Docker e Conectando ao SQL Server Management Studio

#### 6.1 Baixando e Executando o Container do SQL Server

- Execute o seguinte comando para baixar e rodar o container Docker do SQL Server 2022:
  ```bash
  docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=SuaSenhaforte123@' -p 1433:1433 --name sqlserver_container -d mcr.microsoft.com/mssql/server:2022-latest


   7. Implementando o Repositório de Pacientes  
7.1 Criando a Interface
Crie uma interface chamada IPatientRepository.
Defina os métodos para adicionar, atualizar, excluir e buscar pacientes. Isso ajuda a manter a organização e permite que diferentes implementações sejam utilizadas no futuro.
7.2 Implementando o Repositório
Crie a classe PatientRepository, que implementa a interface criada.
Utilize o ApplicationDbContext para realizar operações no banco de dados.
Implemente os métodos de CRUD (Create, Read, Update, Delete):
Adicionar Paciente: Insere um novo paciente no banco de dados.
Atualizar Paciente: Atualiza as informações de um paciente existente.
Deletar Paciente: Remove um paciente baseado no ID fornecido.
Listar Pacientes: Retorna todos os pacientes cadastrados.
Buscar Paciente por ID: Retorna um paciente específico baseado no ID.

7.3 Implementando o Repositório de Pacientes
Crie a interface IPatientRepository para definir métodos de CRUD (adicionar, atualizar, excluir e buscar pacientes).
Em seguida, implemente a classe PatientRepository, utilizando ApplicationDbContext para realizar operações no banco de dados.
Adicione o repositório ao container de injeção de dependência no arquivo Program.cs.
7.4 Implementando o Repositório de Doutores
Crie a interface IDoctorRepository para definir métodos de CRUD para a entidade Doctor.
Implemente a classe DoctorRepository, utilizando ApplicationDbContext para realizar operações no banco de dados e buscar as especialidades do doutor usando Include.
Adicione o repositório ao container de injeção de dependência no Program.cs da aplicação.

7.5 Repositório de Agendamentos (Scheduling)
Criação da Interface ISchedulingRepository:

Define métodos para operações CRUD (criar, ler, atualizar e deletar) e obtenção de agendamentos por ID.
Implementação da Classe SchedulingRepository:

Adicionar Agendamento: Método AddAsync para adicionar um novo agendamento ao banco de dados.
Excluir Agendamento: Método DeleteByIdAsync para remover um agendamento existente pelo ID.
Obter Agendamentos: Métodos GetAllAsync e GetByIdAsync para obter todos os agendamentos e um agendamento específico, respectivamente. Inclui a navegação para Doctor e Patient.
7.6 Repositório de Especialidades (Speciality)
Criação da Interface ISpecialityRepository:

Define o método para obter todas as especialidades.
Implementação da Classe SpecialityRepository:

Obter Especialidades: Método GetAllAsync para listar todas as especialidades no banco de dados.

