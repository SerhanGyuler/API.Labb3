# API

--------------------------------------------------------------------------------------------------------------------------------------
Hämta alla personer i systemet
--------------------------------------------------------------------------------------------------------------------------------------
Metod: GET
Response body
[
  {
    "id": 1,
    "name": "Alice Andersson",
    "phoneNumber": "0701234567",
    "links": []
  },
  {
    "id": 2,
    "name": "Bob Berg",
    "phoneNumber": "0727654321",
    "links": []
  },
  {
    "id": 3,
    "name": "Carla Carlsson",
    "phoneNumber": "0739876543",
    "links": []
  },
  {
    "id": 4,
    "name": "David Dahl",
    "phoneNumber": "0761122334",
    "links": []
  }
]
--------------------------------------------------------------------------------------------------------------------------------------
Hämta alla intressen kopplade till en specifik person
--------------------------------------------------------------------------------------------------------------------------------------
Metod: GET
Response body
{
  "name": "Bob Berg",
  "interests": [
    {
      "url": "https://recept.se/",
      "interestTitle": "Matlagning",
      "interestDescription": "Att laga god mat"
    },
    {
      "url": "https://nordicwellness.se/",
      "interestTitle": "Träning",
      "interestDescription": "Hålla kroppen i form"
    }
  ]
}
--------------------------------------------------------------------------------------------------------------------------------------
Hämta alla länkar kopplade till en specifik person
--------------------------------------------------------------------------------------------------------------------------------------
Metod: GET
Response body
{
  "name": "Bob Berg",
  "links": [
    {
      "url": "https://recept.se/"
    },
    {
      "url": "https://nordicwellness.se/"
    }
  ]
}
--------------------------------------------------------------------------------------------------------------------------------------
Koppla en person till ett nytt intresse
--------------------------------------------------------------------------------------------------------------------------------------
Metod: PUT
Request URL: https://localhost:7105/api/Person/2/1
Respone body:
{
  "message": "Intresset Fotografi kopplades till Bob Berg."
}
Curl: 
curl -X 'PUT' \
  'https://localhost:7105/api/Person/2/1' \
  -H 'accept: */*'
--------------------------------------------------------------------------------------------------------------------------------------
Lägga till nya länkar för en specifik person och ett specifikt intresse
--------------------------------------------------------------------------------------------------------------------------------------
Metod: PUT
Request URL: https://localhost:7105/api/Person/1/2/addlink
Response body:
{
  "message": "Ny länk 'https://www.koket.se/' skapades och kopplades till Alice Andersson och Matlagning."
}
Curl:
curl -X 'PUT' \
  'https://localhost:7105/api/Person/1/2/addlink' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '"https://www.koket.se/"'
--------------------------------------------------------------------------------------------------------------------------------------

