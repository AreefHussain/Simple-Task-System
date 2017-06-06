# Simple-Task-System
Simple Task system For SODING Assessment

Simple Task System project created using visual studio 2015.

The project is an MVC 5.0 project. Default routing changed from "Home View" to Task List View.

SQLite as database (database file in App_data folder) with PETAPOCO ORM.

There is only one controller for managing task named as UserTasksController and two views.

one view for listing Tasks and another one for creating/Assigning tasks.

database tables mapped to classes and using PETAPOCO ORM for CRUD operations.

task creation entry developed with scaffolding technique.

data passing were done using following methods

  1 - model binding
  2 - Viewbag
  3 - Tempdata
    
basic validations provided by default data annotation techniques in ASP.NET MVC.

To prevent SQL injection Parameterised queries were used.

To prevent cross site scripting default machanism in ASP.NET MVC -  AntiForgeryToken were used.

To List Tasks project uses  - GridMvc with basic functionalities 

   1 - Server side pagination
   2 - filtering 
   3 - Sorting

Beacuse of the 2 hours coding time limit you can't see a perfect design pattern.It created with 
basic design principles using OOPS and
project uses defualt mvc 5 template with bootstrap.

