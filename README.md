# Exemplo Consumo API SWAPI 📊📜
O presente projeto tem como finalidade demonstrar um exemplo de como consumir uma API REST para fins de demonstração através de uma aplicação ASP.NET C# MVC 4.8.<br/>
O projeto possui um Board para acompanhamento das issues, tarefas e demais atividades associadas ao mesmo localizado na aba 'Projects => Exemplo-API-SWAPI'.<br/>
A API utilizada neste projeto foi a SWAPI, uma API divertida com foco no poder da guerra nas estrelas rsrs.

## Informações API SWAPI ☕️📌
- 🌍Link API: https://swapi.dev/<br/>
- 📝 Documentação: https://swapi.dev/documentation<br/>
- 📚Relação de Entidades:<br/>
- 🌐Exemplo de response da entidade 'people':<br/>
  - 🖇️Link: https://swapi.dev/api/people/3

## Entidades Disponíveis API SWAPI 📝☕️
```
{
    "people": "https://swapi.dev/api/people/",
    "planets": "https://swapi.dev/api/planets/",
    "films": "https://swapi.dev/api/films/",
    "species": "https://swapi.dev/api/species/",
    "vehicles": "https://swapi.dev/api/vehicles/",
    "starships": "https://swapi.dev/api/starships/"
}
```

## Exemplo Response Entidade: People 3 ☕️📑
```
HTTP 200 OK
Content-Type: application/json
Vary: Accept
Allow: GET, HEAD, OPTIONS

{
    "name": "R2-D2", 
    "height": "96", 
    "mass": "32", 
    "hair_color": "n/a", 
    "skin_color": "white, blue", 
    "eye_color": "red", 
    "birth_year": "33BBY", 
    "gender": "n/a", 
    "homeworld": "https://swapi.dev/api/planets/8/", 
    "films": [
        "https://swapi.dev/api/films/1/", 
        "https://swapi.dev/api/films/2/", 
        "https://swapi.dev/api/films/3/", 
        "https://swapi.dev/api/films/4/", 
        "https://swapi.dev/api/films/5/", 
        "https://swapi.dev/api/films/6/"
    ], 
    "species": [
        "https://swapi.dev/api/species/2/"
    ], 
    "vehicles": [], 
    "starships": [], 
    "created": "2014-12-10T15:11:50.376000Z", 
    "edited": "2014-12-20T21:17:50.311000Z", 
    "url": "https://swapi.dev/api/people/3/"
}
```
## Aprenda o desenvolvimento 🖥️❤️
Este repositório é um projeto gratuito para a comunidade de desenvolvedores para fins de estudos e posteriores contribuições.

## Contribuição 💻✨
Ajude a comunidade tornando este projeto ainda mais incrível através dos seus conhecimentos e contribua conforme for necessário.