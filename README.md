# Blytur Energy API

## Descrição  
A **Blytur Energy API** é uma aplicação desenvolvida em .NET Core para gerenciar e monitorar turbinas de energia eólica e suas medições de energia. Este projeto visa contribuir para processos de energia sustentável, utilizando boas práticas de desenvolvimento, padrões de design e integração com um banco de dados NoSQL (MongoDB). 

A aplicação foi projetada para ser escalável, modular e fácil de manter, seguindo princípios de Clean Code e separação de responsabilidades.

---

## Recursos da API  
1. **Turbinas de Energia**
   - Listar todas as turbinas.
   - Buscar uma turbina por ID.
   - Adicionar uma nova turbina.
   - Atualizar informações de uma turbina existente.
   - Remover uma turbina.
2. **Medições de Energia**
   - Listar todas as medições de uma turbina específica.
   - Adicionar novas medições de energia para uma turbina.

---

## Arquitetura  
A aplicação segue os princípios de separação de responsabilidades, utilizando camadas distintas para organizar o código:

- **Models:** Contém os modelos principais da aplicação.  
- **Interfaces:** define interfaces para os repositórios.
- **Repository:** Implementa as interações com o banco de dados   
- **Services:** Gerencia a lógica de negócios e interage com os repositórios por meio de serviços.  
- **Controller:** Define os controladores que expõem os endpoints da API.

---

## Design Patterns Utilizados  
- **Repository Pattern:**  
  O padrão **Repository** é usado para encapsular a lógica de acesso a dados. Ele fornece uma interface para realizar operações no banco de dados, permitindo desacoplamento e maior testabilidade.

- **Dependency Injection (DI):**  
  A aplicação utiliza injeção de dependência para gerenciar as dependências entre classes, promovendo modularidade e reduzindo o acoplamento.

---

## Tecnologias e Ferramentas  
- **Framework Backend:** .NET Core 7.0  
- **Banco de Dados:** MongoDB  
- **Testes Automatizados:** xUnit e Moq  
- **Documentação da API:** Swagger/OpenAPI  
- **Gerenciamento de Dependências:** NuGet  
- **Código Limpo:** Aplicação de princípios do Clean Code, como nomenclaturas claras, funções pequenas e responsabilidade única.

---

## Endpoints Implementados  
### **Turbinas de Energia**  
| Método | Endpoint         | Descrição                        |
|--------|------------------|----------------------------------|
| GET    | `/api/turbines`  | Lista todas as turbinas.         |
| GET    | `/api/turbines/{id}` | Busca uma turbina por ID.       |
| POST   | `/api/turbines`  | Adiciona uma nova turbina.       |
| PUT    | `/api/turbines/{id}` | Atualiza uma turbina existente. |
| DELETE | `/api/turbines/{id}` | Remove uma turbina.            |

### **Medições de Energia**  
| Método | Endpoint                        | Descrição                                      |
|--------|---------------------------------|-----------------------------------------------|
| GET    | `/api/measurements/{turbineId}` | Lista medições de energia de uma turbina.     |
| POST   | `/api/measurements`            | Adiciona uma nova medição de energia.         |

---

## Configuração do Ambiente  

### Pré-requisitos  
- **.NET SDK 7.0+**  
- **MongoDB 6.0+**  
- Ferramenta para gerenciar dependências, como o Visual Studio ou CLI do .NET.  

### Como Executar  
1. Clone o repositório:  
   ```bash
   git clone https://github.com/SilasHSilva/BlyturEnergyAPI.git
   cd blytur-energy-api

2. Configure a string de conexão do MongoDB no arquivo appsettings.json:
    {
    "ConnectionStrings": {
        "MongoDb": "mongodb://localhost:27017/BlyturEnergy"
        }
    }

3. Execute a aplicação
    ```bash
    dotnet run

### Estrutura de pastas

BlyturEnergyAPI/
├──BlyturEnergyAPI/
|   ├── Controllers/
|   │   ├── EnergyMeasurementController.cs
|   │   ├── TurbineController.cs
|   ├── Interfaces/
|   │   ├── IEnergyMeasurementRepository.cs
|   │   ├── ITurbineRepository.cs
|   ├── Models/
|   │   ├── EnergyMeasurement.cs
|   │   ├── Turbine.cs
|   ├── Repositories/
|   │   ├── EnergyMeasurementRepository.cs
|   │   ├── TurbineRepository.cs
|   ├── Services/
|   │   ├── EnergyMeasurementService.cs
|   │   ├── TurbineService.cs
|   ├── appsettings.json
|   ├── appsettings.Development.json
|   ├── BlyturEnergyAPI.csproj
|   ├── BlyturEnergyAPI.http
|   ├── Program.cs
├── BlyturEnergyAPI.Tests/
│   ├── EnergyMeasurementServiceTests.cs
│   ├── TurbineServiceTests.cs
|   ├── BlyturEnergyAPI.Tests.cs

4. Acesse a documentação da API:
    Acesse o Swagger em `http://localhost:5203/swagger`

## Fluxo de Funcionamento  

1. **Turbinas de Energia**  
   O usuário pode cadastrar turbinas com dados como nome, localização, e capacidade de geração de energia. Essas turbinas serão gerenciadas por meio dos endpoints REST, possibilitando operações de CRUD.

2. **Medições de Energia**  
   Cada turbina pode registrar medições de energia associadas a ela. As medições podem ser consultadas por ID da turbina, permitindo análise detalhada do desempenho de cada unidade.

---

## Integrantes do Grupo

- Eduardo Bezerra – RM: 98890
- Jefferson Mendes de Farias Lima – RM: 552052
- João Vitor Vicente Benjamin – RM: 98938
- Silas Henrique da Silva Oliveira – RM: 98965

