# SiggaBlog

## Objectives
Create a blog with differents albums, each album has many posts and each post has many comments.
This blog allows offline access.

## Composition
* [Fake REST API](https://github.com/jessik126/siggablog.api) hosted on an [instance at Heroku](https://siggaapi.herokuapp.com)
* Mobile application in Xamarin.Forms

## Frameworks and libraries useds in mobile application
* Xam.Plugin.Connectivity 3.2.0 - To verify internet conectivity
* Refit 4.6.107 - To encapsulate the api requisition
* Acr.UserDialogs 7.0.4 - To show any commom components for interface
* Autofac 4.9.2 - IoC
* sqlite-net-pcl 1.5.231 - To create and connect a SQLite Database
* Xamarin.HotReaload 1.3.0 - To live reload at xaml (you don`t need to rebuild the app to see xaml changes, just salve the file)

## Metodologies and Architectures
* Layer architecture in Mobile Application
* MVVM architecture in UI layer, into Mobile Application
* DI (Dependency Injection)
* IoC (Inversion of Control) - To registers data base repositories and call API endpoints

### System Architecture
![System Architecture](https://i.pinimg.com/originals/0c/6d/41/0c6d41a4698aae12c0063a8c2c596d69.png)

### Mobile Architecture
![Mobile Architecture](https://i.pinimg.com/originals/4b/dd/2b/4bdd2bc5771cbeb0e2834d9b57d7feb6.png)

### API Data Base
![API Data Base](https://i.pinimg.com/originals/df/d1/f2/dfd1f281ba50058a748c72df7f7f0e24.png)

### Local Data Base (SQLite)
![Local Data Base](https://i.pinimg.com/originals/8a/81/bf/8a81bf5b42a81d060d969171c0cb639a.png)

## Layout
<img src="https://i.pinimg.com/originals/af/bc/07/afbc071f523120a853a69f80a5d2c001.jpg" width="300">
<img src="https://i.pinimg.com/originals/4b/a8/a2/4ba8a25be6cce3166ee4a879b243465c.jpg" width="300">
<img src="https://i.pinimg.com/originals/3a/ac/b8/3aacb8368cff6c4cac4e300e194118bf.jpg" width="300">
<img src="https://i.pinimg.com/originals/d1/32/71/d1327121b67f6a841b8256809b1d9639.jpg" width="300">

## About
This project was  developed by Jessica S. Campos
