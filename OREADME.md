## Como criar o WEBAPP através do Azure CLI

- Abra o terminal e insira os seguintes comandos: 
    ```bash
    az group create --name rg-blytur --location brazilsouth

	az appservice plan create -n plan-blytur --location brazilsouth -g rg-blytur --sku F1

	az webapp create -g rg-blytur -p plan-blytur --runtime "dotnet:8" -n blyturapp

## Como fazer um CRUD com insomnia ou postman

- Acesse o insomnia e adicione os métodos GET, POST, PUT e DELETE, abaixo estará um exemplo de cada um deles:

### GET - (https://blyturapp.azurewebsites.net/api/turbine)
- A URL acima retornará todas turbinas cadastradas no banco de dados, remetendo o método "READ" do CRUD.

### GET - (https://blyturapp.azurewebsites.net/api/turbine/1)
- A URL acima retornará a turbina cadastrada no banco de dados com o ID: 1, remetendo o método "READ" do CRUD.

### POST - (https://blyturapp.azurewebsites.net/api/turbine)
    {
        "id": "1",
        "name": "Turbina 100",
        "capacity": 22250,
        "location": "Santo André",
        "installationDate": "{% faker 'randomDatePast' %}"
    }
Insira no "BODY" o código JSON com a URL da maneira descrita acima e ele irá cadastrar uma nova Turbina no banco de dados, remetendo o método CREATE do CRUD.

### PUT - (https://blyturapp.azurewebsites.net/api/turbine/1)

    {
        "id": "1",
        "name": "Turbina 500",
        "capacity": 22250,
        "location": "São Paulo",
        "installationDate": "{% faker 'randomDateRecent' %}"
    }

Insira no "BODY" o código JSON com a URL contendo o ID da turbina que você quer alterar da maneira descrita acima e ele irá atualizar a turbina cadastrada no banco de dados, remetendo o método UPDATE do CRUD.

### DELETE - (https://blyturapp.azurewebsites.net/api/turbine/1)

A URL acima excluirá a turbina cadastrada com ID: 1 no banco de dados, remetendo o método "DELETE" do CRUD.

