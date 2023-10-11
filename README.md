# ScryFallManager - v2.0.0
Uma aplicação MVC de gerenciamento de cartas e coleções de Magic the Gathering para o [ScryFall](https://scryfall.com) (não oficial) usando ASP.NET Core e Entity FrameWork

## Funcionalidades
 - Cadastro de Cartas e Coleções
 - Listagem e Detalhamento de Cartas e Coleções
 - Edição e Deleção de Cartas e Coleções
 - Vinculamento de Legalidades e Habilidades de Cartas
 - Caching de Informações
 - Assincronidade de Chamadas
 - Testes Unitários e de Integração

## Tecnologias Ultilizadas
 - C#
 - ASP.NET Core MVC
 - Entity FrameWork
 - Oracle Database

## Configurações e Executando
1. Clone esse Repositório
2. Configure a Conexão no banco no `appsettings.json`
3. Execute esse comando no **Package Manager Console** para criar uma Migração ao banco (substitua o nome para o que desejar):

```Add-Migration [NOME]```

4. Execute esse comando ainda no Console para atualizar as informações no banco:

```Update-Database```

5. Compile e execute a solução.

## Integrantes
 - Enzo Perazolo RM95657
 - Giovanna Sousa RM94767
 - Henry Kinoshita RM93443
 - Matheus Felipe RM93772

## License
Veja o [LICENSE](LICENSE.txt) para direitos de licença e limitações (MIT)
