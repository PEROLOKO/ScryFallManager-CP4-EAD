# Versão 2.0.0 - 11/10/2023

## Entitys
### Removido:
 - Idioma (substituído pelo IdiomaEnum)
### Alterações:
 - Carta:
   - Mudança de Tipo de idioma: Idioma -> IdiomaEnum
 - Coleções:
   - Mudança de Tipo de idioma: Idioma -> IdiomaEnum
 - Habilidade:
   - Novo paramêtro: Descricao: string

## Enumerators:
### Adicionado:
 - IdiomaEnum

## Validation
### Adicionado:
 - ColecaoValidation
 - HabilidadeValidation
 - LegalidadeValidation
### Alterações:
 - CartaValidation:
   - Adicionado Mensagens de erro
   - CustoMana não pode ser nulo
   - Removido validação do Idioma
   - Adicionado validação do IdiomaEnum
   - Arrumado RaridadeEnum para verificar o enum

## Controllers:
### Alterações:
 - Chamdas ao banco agora ultilizam caching e assincronidade