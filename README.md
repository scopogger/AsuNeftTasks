# ПУ "СургутАСУнефть". ПАО "Сургутнефтегаз".
СургутАСУнефть тестовое задание (https://docs.google.com/document/d/1crt5wAU3rx9YiWMNPoppYprlGlfWz1DeSCpn47W8rXA)

<br>

## Часть 1 - Программирование
*5 программ с консольным интерфейсом. Реализация на фреймворке C# .NET 7.0 (Preview).*
<br>
В каждой папке проекта лежат файлы с кодом и exe'шники. Если хотите только их запустить, можете открыть вот эту штуку:
<img src='https://files.catbox.moe/nfhxsi.png'>
<br>если не сработет, то вручную всё же придётся каждый открывать :P

<br>
<br>

## Часть 2 - Базы данных

### Задание №1
*Реализовано прямо в гугл доках с помощью Ctrl+F (ну и фотошопа для наглядности).*
<br>
**Сколько записей в данном фрагменте удовлетворяют условиям:**

##### Вопрос 1. (Категория поезда = «скорый») ИЛИ (Вокзал = «Павелецкий») <br> Я насчитал 9, математично! Ответ: 9 <br>
<img src='https://files.catbox.moe/ttve61.png'>


##### Вопрос 2. (Категория поезда = «скорый») И (Время в пути 40:00) <br> Тут я подумал, что здесь явно есть подвох, но видимо всё же нисколько. Ответ: 0
<img src='https://files.catbox.moe/0dfiw6.png'>


##### Вопрос 3. (Вокзал = «Павелецкий») ИЛИ (Время в пути 35:00) <br> К Павелецкому вокзалу вопросов нет. Ответ: 4
<img src='https://files.catbox.moe/bgc2m3.png'>

<br>
<br>

### Задание №2
*Реализовано на SQLite. Онлайн редактор можно найти <a href="https://sqliteonline.com/">здесь</a>.*
<br>
Таблицы из задачи генерируются и заполняются командами:
<br>

```
CREATE TABLE `Таблица 1` (
	`ID` int,
	`Фамилия_И._О.` string,
	`Пол` string
);
```

```
INSERT INTO 'Таблица 1' VALUES
(1588, 'Саенко М. А.', 'Ж'),
(1616, 'Билич А. П.', 'М'),
(1683, 'Виктюк И. Б.', 'М'),
(1748, 'Кеосаян А. И.', 'Ж'),
(1960, 'Виктюк П. И.', 'М'),
(1974, 'Тузенбах П. А.', 'Ж'),
(2008, 'Виктюк Б. Ф.', 'М'),
(2106, 'Чижик Д. К.', 'Ж'),
(2339, 'Седых Л. А.', 'М'),
(2349, 'Виктюк А. Б.', 'Ж'),
(2521, 'Меладзе К. Г.', 'М'),
(2593, 'Билич П. А.', 'М'),
(2730, 'Виктюк Т. И.', 'Ж'),
(2860, 'Панина Р. Г.', 'Ж'),
(2882, 'Шевченко Г. Р.', 'Ж'),
(2911, 'Седых В. А.', 'Ж');
```

```
CREATE TABLE `Таблица 2` (
	`ID_Родителя` string,
	`ID_Ребенка` string
);
```

```
INSERT INTO 'Таблица 2' VALUES
(1616, 1588),
(2349, 1588),
(2008, 1683),
(2106, 1683),
(1683, 1960),
(2882, 1960),
(2860, 1974),
(2860, 2339),
(2008, 2349),
(2106, 2349),
(1616, 2593),
(2349, 2593),
(1683, 2730),
(2882, 2730),
(1616, 2911),
(2349, 2911);
```

*Так как ответом на задание является текст запроса и его результат, решения могут быть разными. Мои методы не самые оптимизированные, но вроде всё верно в итоге :)*
<br>

##### Вопрос 1. На основании приведённых данных определите ID родного брата Седых В.А.
```
-- Решение в несколько запросов:
1. SELECT `ID` FROM 'Таблица 1' WHERE `Таблица 1`.`Фамилия_И._О.` = 'Седых В. А.'; /* 2911 */
2. SELECT `ID_Родителя` FROM 'Таблица 2' WHERE `Таблица 2`.`ID_Ребенка` = '2911'; /* 1616, 2349 */
3. SELECT DISTINCT `ID_Ребенка` FROM `Таблица 2` WHERE `Таблица 2`.`ID_Родителя` = '1616' OR `Таблица 2`.`ID_Родителя` = '2349'; /* 1588, 2593, 2911 */
4. SELECT `ID` FROM 'Таблица 1' WHERE `Таблица 1`.`ID` = '2349' AND `Таблица 1`.`Пол` = 'М' OR `Таблица 1`.`ID` = '2593' AND `Таблица 1`.`Пол` = 'М'; /* 2593 */
-- Итоговый результат: 2593
```

##### Вопрос 2. Сколько братьев у Саенко М.А.
```
-- Решение в один запрос через несколько SELECT:
SELECT COUNT(*) FROM 'Таблица 1' WHERE `Таблица 1`.`Пол` = 'М' AND `Таблица 1`.`ID` IN (
  SELECT `ID_Ребенка` FROM `Таблица 2` WHERE `Таблица 2`.`ID_Родителя` = (
    SELECT `ID_Родителя` FROM 'Таблица 2' WHERE `Таблица 2`.`ID_Ребенка` = (
      SELECT `ID` FROM 'Таблица 1'
      WHERE `Таблица 1`.`Фамилия_И._О.` = 'Седых В. А.' /* ID ребёнка = 1588. */
    ) /* ID родителей = 1616, 2349 */
  ) /* ID всех детей = 1588, 2593, 2911 */
); /* Мальчик с одинаковыми родителями = 2593 */
-- Итоговый результат: 1
```

##### Вопрос 3. Вывести список детей из неполных семей.
```
-- Решение в один запрос с INNER JOIN:
SELECT `Фамилия_И._О.`
FROM `Таблица 1`
INNER JOIN `Таблица 2`
ON 'Таблица 2'.`ID_Ребенка` = `Таблица 1`.`ID`
GROUP BY `ID_Ребенка`
HAVING COUNT(`ID_Ребенка`) = 1;
-- Итоговый результат:
-- Тузенбах П. А.   //   ID = 1973
-- Седых Л. А.   //   ID = 2339
```
