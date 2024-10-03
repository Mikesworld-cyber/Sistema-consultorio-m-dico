-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: cosmed
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `citas`
--

DROP TABLE IF EXISTS `citas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `citas` (
  `idc` int NOT NULL AUTO_INCREMENT,
  `paciente` varchar(40) DEFAULT NULL,
  `curp` varchar(50) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `hora` varchar(30) DEFAULT NULL,
  `medico` varchar(50) DEFAULT NULL,
  `estatus` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`idc`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `citas`
--

LOCK TABLES `citas` WRITE;
/*!40000 ALTER TABLE `citas` DISABLE KEYS */;
INSERT INTO `citas` VALUES (1,'Maria Gonzalez','ABC123','2023-12-10','10:00:00','Maria Gonz├ílez','pendiente'),(2,'Juan Perez','DEF456','2023-12-11','14:30:00','Pedro Ram├¡rez','terminada'),(3,'Pedro Ramirez','GHI789','2023-12-12','16:45:00','Daniel Hern├índez','pendiente'),(4,'Diego Garcia','GARD890101HDFXRR11','2023-12-11','13:00:00','Dr Maria Gonzalez','finalizada'),(5,'Carlos Martinez','MARC850101HDFXRR02','2023-12-11','09:00:00','Dr Maria Gonzalez','pendiente'),(6,'Carlos Martinez','MARC850101HDFXRR02','2024-01-09','09:00:00','Dr Maria Gonzalez','pendiente'),(7,'Carlos Martinez','MARC850101HDFXRR02','2024-09-19','10:00:00','Dr Maria Gonzalez','pendiente');
/*!40000 ALTER TABLE `citas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consultas`
--

DROP TABLE IF EXISTS `consultas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consultas` (
  `idCons` int NOT NULL AUTO_INCREMENT,
  `paciente` varchar(50) DEFAULT NULL,
  `alturaP` varchar(20) DEFAULT NULL,
  `pesoP` varchar(20) DEFAULT NULL,
  `presion` varchar(20) DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `Hora` time DEFAULT NULL,
  `Medico` varchar(50) DEFAULT NULL,
  `MotivoConsulta` varchar(500) DEFAULT NULL,
  `Diagnostico` varchar(500) DEFAULT NULL,
  `TratamientoRecetado` varchar(500) DEFAULT NULL,
  `curp` varchar(50) DEFAULT NULL,
  `idcita` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`idCons`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consultas`
--

LOCK TABLES `consultas` WRITE;
/*!40000 ALTER TABLE `consultas` DISABLE KEYS */;
INSERT INTO `consultas` VALUES (1,'Maria Gonz├ílez','170 cm','65 kg','120/80','2023-12-10','10:00:00','Dr. Perez','Dolores abdominales','Apendicitis aguda','Cirug├¡a de ap├®ndice','PELJ300101HDFXRR07','2'),(2,'Juan Perez','175 cm','70 kg','110/70','2023-12-11','11:30:00','Dr. Rodriguez','Fiebre y dolor de garganta','Amigdalitis','Antibi├│ticos y reposo','MALM920101MDFXRR06','3'),(3,'Pedro Ram├¡rez','180 cm','80 kg','130/90','2023-12-12','15:45:00','Dra. Garci','Fatiga y mareos','Anemia leve','Suplementos de hierro y dieta balanceada','GARD890101HDFXRR11','5'),(4,'Diego Garc├¡a','1.55','200','180','2023-12-11','13:01:00','Dr Maria Gonzalez','dolor de patas','artritis','amputacion, paracetamol para dolor','GARD890101HDFXRR11','sin cita'),(5,'Diego Garc├¡a','1.55','200','180','2023-12-11','13:01:00','Dr Maria Gonzalez','dolor de patas','artritis','amputacion, paracetamol para dolor','GARD890101HDFXRR11','sin cita'),(6,'Diego Garc├¡a','1.55','200kg','180 psi','2023-12-11','13:04:00','Dr Maria Gonzalez','dolor de patas','artritis cronico','amputacion y paracetamol pa dolor','GARD890101HDFXRR11','4'),(7,'Carlos Martinez','1.50','180','100','2023-12-11','13:40:00','Dr Maria Gonzalez','dolor dr pie','artritis','amputar y paracetamol.','MARC850101HDFXRR02','sin cita'),(8,'Carlos Martinez','555','88','69','2024-01-06','22:46:00','Dr Maria Gonzalez','dolor de cabeza','cancer','paracetamol','MARC850101HDFXRR02','sin cita'),(9,'Carlos Martinez','11','100','12.3','2024-09-17','15:00:00','Dr Maria Gonzalez','dolor de espalda','cancer','tomar paracetamol','MARC850101HDFXRR02','sin cita'),(10,'Carlos Martinez','1.63','80','110','2024-10-02','21:38:00','Dr Maria Gonzalez','Dolor de espalda','Mal postura','Sentarce bien','MARC850101HDFXRR02','sin cita');
/*!40000 ALTER TABLE `consultas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagos`
--

DROP TABLE IF EXISTS `pagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagos` (
  `idpag` int NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `total` float DEFAULT NULL,
  PRIMARY KEY (`idpag`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos`
--

LOCK TABLES `pagos` WRITE;
/*!40000 ALTER TABLE `pagos` DISABLE KEYS */;
INSERT INTO `pagos` VALUES (1,'2023-12-10','10:00:00',50),(2,'2023-12-11','14:30:00',75.5),(3,'2023-12-12','16:45:00',100.25);
/*!40000 ALTER TABLE `pagos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `idu` int NOT NULL AUTO_INCREMENT,
  `nombres` varchar(50) DEFAULT NULL,
  `apellidos` varchar(50) DEFAULT NULL,
  `edad` int DEFAULT NULL,
  `telefono` varchar(50) DEFAULT NULL,
  `usuario` varchar(40) DEFAULT NULL,
  `correo` varchar(50) DEFAULT NULL,
  `contrasena` varchar(40) DEFAULT NULL,
  `tipoUsuario` varchar(40) DEFAULT NULL,
  `curp` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idu`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'miguel','cauich pech',30,'123456789','mike','mike@example.com','4321','medico','PELJ300101HDFXRR07'),(2,'Maria','Gonzalez',25,'987654321','mariagonz','maria@example.com','password456','medico','GOMM950101MDFXRR01'),(3,'Carlos','Martinez',35,'555555555','carlosmart','carlos@example.com','clave789','paciente','MARC850101HDFXRR02'),(4,'Juan','Perez',30,'1234567890','juanp','juan@example.com','contrasea1','medico','PELJ300101HDFXRR03'),(5,'Mar├¡a','L├│pez',25,'9876543210','marial','maria@example.com','contrasea2','paciente','LOPM950101MDFXRR04'),(6,'Pedro','G├│mez',35,'5551234567','pedrog','pedro@example.com','contrasea3','medico','GOMP850101HDFXRR05'),(7,'Laura','Mart├¡nez',28,'7779998888','lauram','laura@example.com','contrasea4','paciente','MALM920101MDFXRR06'),(8,'Carlos','S├ínchez',40,'3332221111','carloss','carlos@example.com','contrasea5','admin','SACC820101HDFXRR07'),(9,'Ana','Ram├¡rez',22,'6667778888','anar','ana@example.com','contrasea6','empleado','RAAA000101MDFXRR08'),(10,'Daniel','Hern├índez',29,'9998887777','danield','daniel@example.com','contrasea7','paciente','HELD910101HDFXRR09'),(11,'Sof├¡a','Torres',27,'4445556666','sofiat','sofia@example.com','contrasea8','admin','TOSA950101MDFXRR10'),(12,'Diego','Garc├¡a',33,'2223334444','diegog','diego@example.com','contrasea9','paciente','GARD890101HDFXRR11'),(13,'Elena','D├¡az',31,'1112223333','elenad','elena@example.com','contrasea10','medico','DIAE900101MDFXRR12');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-02 22:01:57
