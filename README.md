# AE3AF-finalProject01

## task description 

Choose one API:
-	The Lord of the Rings API https://the-one-api.dev/ 
-	Game of Thrones API https://anapioficeandfire.com/Documentation 
-	Breaking Bad API https://breakingbadapi.com/documentation 
-	Star Wars API https://swapi.dev/ 
-	If you find another one, feel free to use it!

Each API contains information about characters, episodes/books/movies, quotes… Your task is to display at least two groups of information (example: characters and movies from The Lord of the Rings API) using CollectionView (separate pages) and when you tap on an item, you will navigate to its corresponding Detail page in order to see more information about it.

Also, in Details page, include an option to share information about it (choose at least two: email, SMS, social network, …).

General requirements:
-	Use MVVM. Very few code will be allowed in the View
-	You can use Xamarin.Essentials for the Share part
-	You can use Xamarin.Forms Shell for the menu part
-	Marking a movie as favorite means that you will save its information in a local Sqlite database (You can save it to a remote database instead if you want, but you’ll need to set up an API for that-).
-	Use styles defined in App.xaml or inside every page

## app description

* The app shows info about the breaking bas show's characters and episodes 
* user can click on a character and view the information about them
* the user can add characters to theri favourites
* the user can choose a season and choose an episode of the selected season
* the user can view an episode's info and add it to favourites
* the user can view the most popular coutes from the show

## app solution

* the app was developed using Xamarin forms
* the app uses MVVM
* the app connects to an external api ==> [linl](https://breakingbadapi.com/documentation)

## app pictures

#### main page

![main page](https://github.com/ap-Camel/AE3AF-finalProject01/blob/master/Pictures/Screenshot%202022-03-31%20120123.png)


#### character page

![character age](https://github.com/ap-Camel/AE3AF-finalProject01/blob/master/Pictures/Screenshot%202022-03-31%20120224.png)


#### seasons page

![seasons page](https://github.com/ap-Camel/AE3AF-finalProject01/blob/master/Pictures/Screenshot%202022-03-31%20120339.png)


#### episodes page

![episodes page](https://github.com/ap-Camel/AE3AF-finalProject01/blob/master/Pictures/Screenshot%202022-03-31%20120406.png)


#### episode details page

![episode page](https://github.com/ap-Camel/AE3AF-finalProject01/blob/master/Pictures/Screenshot%202022-03-31%20120428.png)


#### quotes page

![qoutes page](https://github.com/ap-Camel/AE3AF-finalProject01/blob/master/Pictures/Screenshot%202022-03-31%20120527.png)


#### favourites page

![favourites page](https://github.com/ap-Camel/AE3AF-finalProject01/blob/master/Pictures/Screenshot%202022-03-31%20120554.png)


