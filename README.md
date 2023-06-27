# DigitalMenu

DigitalMenu é um projeto de estudo para a fase 1 da pós graduação da FIAP (Arquitetura de Sistemas .NET com Azure). 
A aplicação web é utilizada para Front End, enquanto a Web API faz a interação com o banco de dados.
Foi utilizado o SQL Azure como banco de dados e o Azure Blob Storage foi utilizado para armazenamento das imagens/anexo cadastradas com a aplicação.

O serviço em si, inclui uma página onde serão realizados os cadastros de 'pratos', com a opção para inclusão da imagem. Outra página irá realizar a busca dos dados cadastrados no SQL Azure, bem como exibição da imagem (caso exista) armazenada no blob storage, onde também será possível remover e editar. (Essa será visão proprietário do estabelecimento - após implementação de autenticação de usuário, será visualizado apenas pelo adm)

Foi feito um escopo inicial de adição de pratos no carrinho e página inicial onde é visualizado o catálogo de pratos cadastrados (Essa será a unica visão do cliente geral do estabelecimento - após implementação de autenticação de usuário)

## Usage

Para testar localmente, é necessário iniciar os dois csprojs da solution: WebAPI & Web. Além da criação dos recursos no Azure: Resource Group, Server com Database e Table, e Storage Account com o container para armazendo dos arquivos.
(atualizar as secrets no appSettings)


```sql
CREATE TABLE Dish (id int identity primary key, name varchar(60), description varchar(100), price float, attachmentName varchar(max))
```

## Contributing






## License
