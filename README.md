
# Мениджър на отпуски

**1.	Бърз преглед**<br/>
Мениджърът на отпуски (“Vacation Manager”) е система, която служи за управлението на отпуски в рамките на дадена организация. Нещо повече, системата се използва за управление на проекти, екипи и роли в организацията. Поддържа се подаване на заявка за платен, неплатен и болничен отпуск. Заявката трябва да бъде одобрена от лидера на екипа или управителя (CEO) на компанията.

**2.	Компоненти**<br/>
Vacation Manager се състои от два основни компонента – база от данни и уеб приложение със слой, комуникиращ с базата от данни. 

**3.	Функционалност**<br/>
**Потребители**<br/>
Системата работи с потребители и всеки потребител има потребителско име и парола за достъп до функционалността на системата. Всеки потребител трябва да има:
- потребителско име
- парола
- собствено име
- фамилия
- роля
- екип

Допълнително, според ролята си даден потребител може да има воден от него екип. Всеки потребител трябва да може да изпраща и разглежда изпратените от него заявки за платен, неплатен и болничен отпуск. Системата поддържа CRUD операции за потребители, като те са достъпни само за потребители с роля “CEO”. Освен това, система има изглед за показване на всички потребители (страницирано), както и филтрирането им (търсене по потребителско име, собствено име, фамилия или роля). Възможно е показването на изглед с детайлна информация за всеки потребител, откъдето може и да се зададе екип, към който да принадлежи потребителя.

**Роли**<br/>
	Ролите в системата са както следва: “CEO”, “Developer”, “Team Lead” и “Unassigned” за потребители, които още не са получили своята роля. Всяка роля име само име и потребители, които са назначени на ролята. Съществува изглед за показване на всички роли заедно с броя на потребителите, които имат тази роля. Системата поддържа CRUD операции за ролите, като отново те са достъпни за потребителите с роля CEO. Възможно е показването на всички потребители от дадена роля.

**Екипи**<br/>
Всеки потребител може да бъде част от екип, а всеки екип си има:
- име
- проект, по който работи
- разработчици
- лидер на екипа

Аналогично, системата поддъжа CRUD операции за екип, както и изгледи подобни на тези за потребител. Екипите могат да се филтрират по име на проект или име на екипа. На страницата с детайли се показват всички разработчици, които са в екипа, кой е лидерът и цялата информация относно екипа + опция да се премахне, добави член на екипа. 

**Проекти**<br/>
Системата поддържа също и CRUD операции за проект, каот всеки проект има:
- име
- описание
- екипи, които работят по проекта

Отново изгледите са аналогични, като проектите могат да се филтрират по име и описание. На детайлния изглед освен данните за проекта се показва и списък с всички екипи, които работят по него, с опция да се добави, премахне екип.

>Забележка: За всеки изглед, върху който се показват всички данни (например всички потребители), трябва да се поддържа показване на страници, като за големина по подразбиране нека една страница да е с големина 10 записа. Големината на страницата да може да се конфигурира през изгледа (например опции за показване на 10, 25 или 50 записа).

**Отпуски**<br/>
	Потребителят трябва да има възможност да прави заявки за отпуск, като възможните опции са за платен, неплатен и болничен отпуск. В общия случай заявката трябва да има:
- дата - от
- дата – до
- дата създаване на заявката
- половин ден отпуск (вярно или невярно)
- одобрена (вярно или невярно)
- заявител

При заявката за болничен отпуск трябва да има и прикачен файл – болничен картон/лист, както и да липсва опцията за половин ден.
Дадена заявка може да се одобрява само от по-високостоящ служител, т.е. CEO или лидерът на екипа, в който е даден потребител. Ако самият лидер е в отпуск, заявката може да бъде одобрена отново от по-високостоящ. 
Всеки потребител трябва да има възможност да вижда своите заявки, да ги трие преди да бъдат одобрени, да ги редактира и да изпраща нови. При заявката за болничен отпуск има и опция за сваляне на прикачения файл. Заявките за отпуск се показват отново страницирано, като могат да се филтрират по дата (да се показват само заявки, създадени след посочената дата).
Потребителите с роля „Team Lead” или ”CEO” могат да одобряват заявки изпратени съответно от членове на водения екип, от всички служители (CEO). В противен случай заявката може да бъде изтрита.

**4.	Допълнителни изисквания**<br/>
Всяка форма в уеб приложението трябва да е валидирана – не се приемат празни символни низове и тн. Подсигурете, че не се въвеждат отрицателни дати, където не трябва, както и че не се въвеждат прекалено дъгли символни низове.

# Основи на оценяване:
1.  Реализиране на управление на потребители и вход в системата
2.  Реализиране на роли в системата и ограничаване на достъп съответно ролята
3.  Управление на екипи
4.  Управление на проекти
5.  Управление на отпуски
6.  Одобрение на отпуска
7.  Прехвърляне на одобрение на отпуска към управутел