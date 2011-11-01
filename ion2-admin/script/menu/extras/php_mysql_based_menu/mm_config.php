<?php

/*
   This is the config file for setting up database driven menus
   The settings here are pretty much self explanitory and should be straight forward
   for somebody who has a little knowldge of PHP and MySQL
*/

$dbHost = 'localhost';              // Where is the MySQL Server located
$dbName = 'mysql_db';                   // The name of the database
$dbUser = 'mysql_user';                // MySQL username
$dbPasswd = 'mysql_password';              // MySQL password

$sendErrorReports=true;             // Send MySQL error messages via email
$adminEmail = "you@yourwebsite.com";   // Email address of user who should get MySQL error reports

$table_prefix = 'mm_';              // Prefix of menu tables

$pathToCodeFiles="http://www.yourwebsite.com/";               // The www root to where the menu code files are located

/// The following is only changed if the name of the menu code files have been changed.
$menuVars=array();
$menuVars["pathToCodeFiles"]=$pathToCodeFiles;
$menuVars["file_milonicsrc"]="milonic_src.js";
$menuVars["file_mmenudom"]="mmenudom.js";
$menuVars["file_mmenuns4"]="mmenuns4.js";

?>