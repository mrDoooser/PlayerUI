-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: football
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Coatchers`
--

DROP TABLE IF EXISTS `Coatchers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Coatchers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Coatchers`
--

LOCK TABLES `Coatchers` WRITE;
/*!40000 ALTER TABLE `Coatchers` DISABLE KEYS */;
INSERT INTO `Coatchers` VALUES (1,'Кислый З.'),(2,'Сладкий А.');
/*!40000 ALTER TABLE `Coatchers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Leagues`
--

DROP TABLE IF EXISTS `Leagues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Leagues` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Leagues`
--

LOCK TABLES `Leagues` WRITE;
/*!40000 ALTER TABLE `Leagues` DISABLE KEYS */;
INSERT INTO `Leagues` VALUES (1,'Мария');
/*!40000 ALTER TABLE `Leagues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Matches`
--

DROP TABLE IF EXISTS `Matches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Matches` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `LeagueID` int(11) DEFAULT NULL,
  `StadiumID` int(11) DEFAULT NULL,
  `TourID` int(11) DEFAULT NULL,
  `ViewersCount` int(11) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `Matches_leagueID_idx` (`LeagueID`),
  KEY `Matches_StadiumID_idx` (`StadiumID`),
  KEY `Matches_TourID_idx` (`TourID`),
  CONSTRAINT `Matches_StadiumID` FOREIGN KEY (`StadiumID`) REFERENCES `Stadiums` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Matches_TourID` FOREIGN KEY (`TourID`) REFERENCES `Tours` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Matches_leagueID` FOREIGN KEY (`LeagueID`) REFERENCES `Leagues` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Matches`
--

LOCK TABLES `Matches` WRITE;
/*!40000 ALTER TABLE `Matches` DISABLE KEYS */;
INSERT INTO `Matches` VALUES (1,1,1,1,25625,NULL);
/*!40000 ALTER TABLE `Matches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Players`
--

DROP TABLE IF EXISTS `Players`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Players` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Players`
--

LOCK TABLES `Players` WRITE;
/*!40000 ALTER TABLE `Players` DISABLE KEYS */;
INSERT INTO `Players` VALUES (1,'Player 1.1'),(2,'Player 1.1'),(3,'Player 1.3'),(4,'Player 1.4'),(5,'Player 1.5'),(6,'Player 1.6'),(7,'Player 1.7'),(8,'Player 1.8'),(9,'Player 1.9'),(10,'Player 1.10'),(11,'Player 1.11'),(12,'Player 1.12'),(13,'Player 1.13'),(14,'Player 1.14'),(15,'Player 1.15'),(16,'Player 1.16'),(17,'Player 1.17'),(18,'Player 2.1'),(19,'Player 2.2'),(20,'Player 2.3'),(21,'Player 2.4'),(22,'Player 2.5'),(23,'Player 2.6'),(24,'Player 2.7'),(25,'Player 2.8'),(26,'Player 2.9'),(27,'Player 2.10'),(28,'Player 2.11'),(29,'Player 2.12'),(30,'Player 2.13'),(31,'Player 2.14'),(32,'Player 2.15'),(33,'Player 2.16'),(34,'Player 2.17'),(35,'Player 2.18'),(36,'Player 2.19'),(37,'Player 2.20'),(38,'Player 2.21');
/*!40000 ALTER TABLE `Players` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Roles`
--

DROP TABLE IF EXISTS `Roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Roles`
--

LOCK TABLES `Roles` WRITE;
/*!40000 ALTER TABLE `Roles` DISABLE KEYS */;
INSERT INTO `Roles` VALUES (1,'(ГК)'),(2,'(К)');
/*!40000 ALTER TABLE `Roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Stadiums`
--

DROP TABLE IF EXISTS `Stadiums`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Stadiums` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Stadiums`
--

LOCK TABLES `Stadiums` WRITE;
/*!40000 ALTER TABLE `Stadiums` DISABLE KEYS */;
INSERT INTO `Stadiums` VALUES (1,'Центральный городской');
/*!40000 ALTER TABLE `Stadiums` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TeamCoatchers`
--

DROP TABLE IF EXISTS `TeamCoatchers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TeamCoatchers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CoatchID` int(11) DEFAULT NULL,
  `TeamID` int(11) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `IsActive` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `id_idteam` (`TeamID`),
  CONSTRAINT `teamID` FOREIGN KEY (`TeamID`) REFERENCES `Teams` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TeamCoatchers`
--

LOCK TABLES `TeamCoatchers` WRITE;
/*!40000 ALTER TABLE `TeamCoatchers` DISABLE KEYS */;
/*!40000 ALTER TABLE `TeamCoatchers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TeamPlayers`
--

DROP TABLE IF EXISTS `TeamPlayers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TeamPlayers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime DEFAULT NULL,
  `TeamID` int(11) DEFAULT NULL,
  `PlayerID` int(11) DEFAULT NULL,
  `PlayerNumber` varchar(3) DEFAULT NULL,
  `MainRoleID` int(11) DEFAULT NULL,
  `IsActive` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `teamID_idx` (`TeamID`),
  KEY `playerID_idx` (`PlayerID`),
  KEY `TeamPlayers_teamID_idx` (`TeamID`),
  KEY `TeamPlayers_playerID_idx` (`PlayerID`),
  CONSTRAINT `TeamPlayers_playerID` FOREIGN KEY (`PlayerID`) REFERENCES `Players` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TeamPlayers_teamID` FOREIGN KEY (`TeamID`) REFERENCES `Teams` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TeamPlayers`
--

LOCK TABLES `TeamPlayers` WRITE;
/*!40000 ALTER TABLE `TeamPlayers` DISABLE KEYS */;
INSERT INTO `TeamPlayers` VALUES (1,NULL,1,1,'1',1,NULL),(2,NULL,1,2,'2',2,NULL),(3,NULL,1,3,'3',NULL,NULL),(4,NULL,1,4,'4',NULL,NULL),(5,NULL,1,5,'5',NULL,NULL),(6,NULL,1,6,'6',NULL,NULL),(7,NULL,1,7,'7',NULL,NULL),(8,NULL,1,9,'9',NULL,NULL),(9,NULL,1,8,'8',NULL,NULL),(10,NULL,1,10,'10',NULL,NULL),(11,NULL,1,11,'11',NULL,NULL),(12,NULL,1,12,'12',NULL,NULL),(13,NULL,1,13,'13',NULL,NULL),(14,NULL,1,14,'14',NULL,NULL),(15,NULL,1,15,'15',NULL,NULL),(16,NULL,1,16,'16',NULL,NULL),(17,NULL,1,17,'17',NULL,NULL),(18,NULL,2,18,'1',1,NULL),(19,NULL,2,19,'2',2,NULL),(20,NULL,2,20,'3',NULL,NULL),(21,NULL,2,21,'4',NULL,NULL),(22,NULL,2,22,'5',NULL,NULL),(23,NULL,2,23,'6',NULL,NULL),(24,NULL,2,24,'7',NULL,NULL),(25,NULL,2,25,'9',NULL,NULL),(26,NULL,2,26,'8',NULL,NULL),(27,NULL,2,28,'10',NULL,NULL),(28,NULL,2,27,'11',NULL,NULL),(29,NULL,2,29,'12',NULL,NULL),(30,NULL,2,30,'13',NULL,NULL),(31,NULL,2,31,'14',NULL,NULL),(32,NULL,2,32,'15',NULL,NULL),(33,NULL,2,33,'16',NULL,NULL),(34,NULL,2,34,'17',NULL,NULL);
/*!40000 ALTER TABLE `TeamPlayers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TeamSolutionOnMatch`
--

DROP TABLE IF EXISTS `TeamSolutionOnMatch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TeamSolutionOnMatch` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TeamID` int(11) DEFAULT NULL,
  `PlayerID` int(11) DEFAULT NULL,
  `PlayerNumber` varchar(3) DEFAULT NULL,
  `PlayerRoleID` int(11) DEFAULT NULL,
  `InMainSquad` int(1) DEFAULT NULL,
  `MatchID` int(11) DEFAULT NULL,
  `MainSquare` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `TeamSolutionOnMatch_TeamID_idx` (`TeamID`),
  KEY `TeamSolutionOnMatch_PlayerID_idx` (`PlayerID`),
  KEY `TeamSolutionOnMatch_RoleID_idx` (`PlayerRoleID`),
  KEY `TeamSolutionOnMatch_MatchID_idx` (`MatchID`),
  CONSTRAINT `TeamSolutionOnMatch_MatchID` FOREIGN KEY (`MatchID`) REFERENCES `Matches` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TeamSolutionOnMatch_PlayerID` FOREIGN KEY (`PlayerID`) REFERENCES `Players` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `TeamSolutionOnMatch_RoleID` FOREIGN KEY (`PlayerRoleID`) REFERENCES `Roles` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `TeamSolutionOnMatch_TeamID` FOREIGN KEY (`TeamID`) REFERENCES `Teams` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TeamSolutionOnMatch`
--

LOCK TABLES `TeamSolutionOnMatch` WRITE;
/*!40000 ALTER TABLE `TeamSolutionOnMatch` DISABLE KEYS */;
INSERT INTO `TeamSolutionOnMatch` VALUES (1,1,1,'1',1,1,1,35),(2,1,2,'2',2,1,1,6),(3,1,3,'3',NULL,1,1,8),(4,1,4,'4',NULL,1,1,12),(5,1,5,'5',NULL,1,1,15),(6,1,6,'6',NULL,1,1,19),(7,1,7,'7',NULL,1,1,21),(8,1,8,'8',NULL,1,1,23),(9,1,9,'9',NULL,1,1,25),(10,1,10,'10',NULL,1,1,31),(11,1,11,'11',NULL,1,1,33),(12,1,12,'12',NULL,0,1,NULL),(13,1,13,'13',NULL,0,1,NULL),(14,1,14,'14',NULL,0,1,NULL),(15,1,15,'15',NULL,0,1,NULL),(16,1,16,'16',NULL,0,1,NULL),(17,1,17,'17',NULL,0,1,NULL),(18,2,18,'1',1,1,1,35),(19,2,19,'2',2,1,1,5),(20,2,20,'3',NULL,1,1,0),(21,2,21,'4',NULL,1,1,10),(22,2,22,'5',NULL,1,1,15),(23,2,23,'6',NULL,1,1,20),(24,2,24,'7',NULL,1,1,25),(25,2,25,'8',NULL,1,1,30),(26,2,26,'9',NULL,1,1,32),(27,2,27,'10',NULL,1,1,29),(28,2,28,'11',NULL,1,1,33),(29,2,29,'12',NULL,0,1,NULL),(30,2,30,'13',NULL,0,1,NULL),(31,2,31,'14',NULL,0,1,NULL),(32,2,32,'15',NULL,0,1,NULL),(33,2,33,'16',NULL,0,1,NULL),(34,2,34,'17',NULL,0,1,NULL);
/*!40000 ALTER TABLE `TeamSolutionOnMatch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Teams`
--

DROP TABLE IF EXISTS `Teams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Teams` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `ShortName` varchar(8) DEFAULT NULL,
  `MainCoatch` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `Name_idx` (`Name`),
  KEY `Shortname_idx` (`ShortName`),
  KEY `coatchID_idx` (`MainCoatch`),
  CONSTRAINT `coatchID` FOREIGN KEY (`MainCoatch`) REFERENCES `Coatchers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Teams`
--

LOCK TABLES `Teams` WRITE;
/*!40000 ALTER TABLE `Teams` DISABLE KEYS */;
INSERT INTO `Teams` VALUES (1,'Реал М.',NULL,1),(2,'Барселона.',NULL,2);
/*!40000 ALTER TABLE `Teams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tours`
--

DROP TABLE IF EXISTS `Tours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tours` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tours`
--

LOCK TABLES `Tours` WRITE;
/*!40000 ALTER TABLE `Tours` DISABLE KEYS */;
INSERT INTO `Tours` VALUES (1,'38-й');
/*!40000 ALTER TABLE `Tours` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-14 13:54:47
