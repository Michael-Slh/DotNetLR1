# Lab01

## Модель
Були додані унікальні ідентифікатори для усіх моделей та додатково для маршрутів змінені типи полів, які містили початкову та кінцеву точку - на екземпляри класів Point та, відповідно, змінені запити, у яких замість групуваня по ідентифікаторам використовувалося групування по простим назвам.

## Повернення значень
До зміни методи, що відповідали за самі запити, одночасно і друкували результат запитів, що порушувало SRP. Було змінено методи, щоб вони повертали значення та потім ці значення використовувалися у Program.cs належним чином.
