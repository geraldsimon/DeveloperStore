# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - O projeto segue boas práticas de navegação para aplicações MVC/API.
    - Controle de rotas e estrutura de endpoints bem definida na API.

  * Pontos negativos:
    - Nenhum ponto negativo identificado neste aspecto.

### Design
  - Projeto não possui camada visual MVC, sendo focado em API REST. A documentação via Swagger supre parte da navegação de testes.

### Funcionalidade
  * Pontos positivos:
    - CRUD completo implementado para entidades do domínio.
    - Registro de usuários com ASP.NET Identity.
    - Autenticação JWT funcional na API.
    - Uso de SQLite, migrations automáticas e seed de dados implementado.

  * Pontos negativos:
    - Nenhum.

## Back End

### Arquitetura
  * Pontos positivos:
    - Projeto dividido em camadas claras: API, App, Business e Data.
    - Boas práticas com classes de configuração, injeção de dependência e organização modular.
    - Uso de abstrações entre camadas respeitado.

  * Pontos negativos:
    - A presença da classe `ApplicationUser` dentro da camada de domínio (`Business`) gera acoplamento desnecessário à infraestrutura de autenticação.

  * Observações:    
    - Um único projeto `Core` (unindo regras e acesso a dados) atenderia com mais simplicidade e coesão ao escopo proposto.

### Funcionalidade
  * Pontos positivos:
    - Registro e login de usuários com identidade separados da lógica de domínio.
    - Associações corretas entre produtos e usuários autenticados.
    - Proteção de endpoints conforme esperado.

  * Pontos negativos:
    - Nenhum.

### Modelagem
  * Pontos positivos:
    - Entidades bem definidas.
    - Relacionamentos implementados de forma adequada.
    - Uso adequado de validações.

  * Pontos negativos:
    - A herança entre `ApplicationUser` e uma entidade de domínio desvirtua o papel do Identity no projeto.

## Projeto

### Organização
  * Pontos positivos:
    - Estrutura de pastas com `src`, solution na raiz, e arquivos organizados.
    - Nomeação dos projetos clara e consistente com suas funções.

  * Pontos negativos:
    - Projeto usa nomes e estrutura em inglês, o que está em desacordo com a linguagem de negócio estabelecida (português).

### Documentação
  * Pontos positivos:
    - README.md presente com informações úteis.
    - Arquivo `FEEDBACK.md` incluso.
    - Swagger disponível na API.

### Instalação
  * Pontos positivos:
    - Configuração para SQLite, migrations e seed de dados funcionando corretamente.

  * Pontos negativos:
    - Nenhum ponto negativo.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 10       | 3,0                                      |
| **Qualidade do Código**       | 20%      | 10       | 2,0                                      |
| **Eficiência e Desempenho**   | 20%      | 9        | 1,8                                      |
| **Inovação e Diferenciais**   | 10%      | 10       | 1,0                                      |
| **Documentação e Organização**| 10%      | 9        | 0,9                                      |
| **Resolução de Feedbacks**    | 10%      | 8        | 0,8                                      |
| **Total**                     | 100%     | -        | **9,5**                                  |

## 🎯 **Nota Final: 9,5 / 10**
