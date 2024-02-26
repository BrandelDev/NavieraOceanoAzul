-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: noa
-- ------------------------------------------------------
-- Server version	5.7.44-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `asignacion_puerto_barco`
--

DROP TABLE IF EXISTS `asignacion_puerto_barco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asignacion_puerto_barco` (
  `idAsignacionPuertoBarco` int(11) NOT NULL AUTO_INCREMENT,
  `idbarco` int(11) DEFAULT NULL,
  `idpuerto` int(11) DEFAULT NULL,
  PRIMARY KEY (`idAsignacionPuertoBarco`),
  KEY `ABFK_idx` (`idbarco`),
  KEY `APFK_idx` (`idpuerto`),
  CONSTRAINT `ABFK` FOREIGN KEY (`idbarco`) REFERENCES `barco` (`idbarco`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `APFK` FOREIGN KEY (`idpuerto`) REFERENCES `puertos` (`idPuertos`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignacion_puerto_barco`
--

LOCK TABLES `asignacion_puerto_barco` WRITE;
/*!40000 ALTER TABLE `asignacion_puerto_barco` DISABLE KEYS */;
INSERT INTO `asignacion_puerto_barco` VALUES (1,7,1),(2,9,3),(3,10,4),(4,11,5),(5,12,6),(6,7,7),(7,8,8),(8,9,9),(9,10,10),(10,11,11),(11,12,12);
/*!40000 ALTER TABLE `asignacion_puerto_barco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `barco`
--

DROP TABLE IF EXISTS `barco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `barco` (
  `idbarco` int(11) NOT NULL AUTO_INCREMENT,
  `capacidad_personas` int(11) DEFAULT NULL,
  `capacidad_carga` decimal(20,0) DEFAULT NULL,
  `nombre_barco` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idbarco`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `barco`
--

LOCK TABLES `barco` WRITE;
/*!40000 ALTER TABLE `barco` DISABLE KEYS */;
INSERT INTO `barco` VALUES (7,50,50,'hola'),(8,50,50,'noa'),(9,80,900,'El Holandes'),(10,80,900,'La peña'),(11,80,900,'La estrella de Mar'),(12,100,900,'El Mareño');
/*!40000 ALTER TABLE `barco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `idcliente` int(11) NOT NULL AUTO_INCREMENT,
  `primer_nombre` varchar(45) DEFAULT NULL,
  `segundo_nombre` varchar(45) DEFAULT NULL,
  `primer_apellido` varchar(45) DEFAULT NULL,
  `segundo_apellido` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `contrasena` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (4,'Brandel','Daniel','Otero','Arango','daniel.otero128@gmail.com','$2a$11$DNCNgScXjp/XMkDmpHQHeecQ2UUZ6V4rTCyK.Xvuk5LZg./9TIbEO'),(5,'Maria','Hola','Perras','Daniel','holaquemas@gmail.com','$2a$11$eWWWB3/mzCjJtX6AIXB2sOxw3dnrIY2eNBC6mCv19shwC.pNfP.4m'),(6,'El putas','De aguadas','Otero','Otero','mariadelaverga','$2a$11$Idiy50991cKyunNG.FN9yOFxsJTFtKMX0bD7FjklcYzP6p5.fKfH2'),(7,'Hermes','Augusto','Otero','Urzola','hermesotero@gmail.com','$2a$11$qkn4xc0IxsTVgfcB0kZeZOTjKfRenLbKmJttIvGdgGnmOaJgUSFqm');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habitaciones`
--

DROP TABLE IF EXISTS `habitaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `habitaciones` (
  `idhabitaciones` int(11) NOT NULL AUTO_INCREMENT,
  `numero_habitacion` varchar(45) DEFAULT NULL,
  `capacidad` varchar(45) DEFAULT NULL,
  `ubicacion_habitacion` varchar(45) DEFAULT NULL,
  `idbarco` int(11) DEFAULT NULL,
  PRIMARY KEY (`idhabitaciones`),
  KEY `barcoFk_idx` (`idbarco`),
  CONSTRAINT `BarcoFk_1` FOREIGN KEY (`idbarco`) REFERENCES `barco` (`idbarco`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habitaciones`
--

LOCK TABLES `habitaciones` WRITE;
/*!40000 ALTER TABLE `habitaciones` DISABLE KEYS */;
INSERT INTO `habitaciones` VALUES (1,'Cuarto de Mando','10 personas','Proa',7),(2,'Camarote Principal','4 personas','Popa',7),(3,'Camarote de Tripulación','2 personas','Estribor',7),(4,'B304','2 personas','Babor',7),(5,'A102','4 personas','Estribor',7),(6,'C215','3 personas','Cubierta Superior',7),(7,'D401','2 personas','Popa',7),(8,'C112','1 persona','Cubierta Principal',7),(9,'F205','2 personas','Cubierta Inferior',7),(10,'D503','3 personas','Estribor',7),(11,'B601','2 personas','Cubierta Superior',7),(12,'A101','4 personas','Popa',12),(13,'E401','2 personas','Cubierta Superior',12),(14,'C204','3 personas','Cubierta Principal',12),(15,'D302','2 personas','Estribor',12),(16,'B601','5 personas','Cubierta Inferior',11),(17,'A402','2 personas','Camarote',11),(18,'C305','4 personas','Popa',11),(19,'C305','4 personas','Popa',10),(20,'B202','2 personas','Camarote de Lujo',10),(21,'A105','3 personas','Cubierta Principal',10),(22,'C404','4 personas','Cubierta Superior',10);
/*!40000 ALTER TABLE `habitaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puertos`
--

DROP TABLE IF EXISTS `puertos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `puertos` (
  `idPuertos` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `ciudad` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idPuertos`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puertos`
--

LOCK TABLES `puertos` WRITE;
/*!40000 ALTER TABLE `puertos` DISABLE KEYS */;
INSERT INTO `puertos` VALUES (1,'Puerto de Tumaco','Tumaco'),(2,'Puerto de Cartagena','Cartagena'),(3,'Barranquilla','Cartagena'),(4,'Puerto de Santa Martaa','Santa Marta'),(5,'Puerto de Buenaventura','Buenaventura'),(6,'Puerto de Long Beach','Long Beach'),(7,'Puerto de Róterdam','Róterdam'),(8,'Puerto de Shanghái','Shanghái'),(9,'Puerto de Los Ángeles','Los Ángeles'),(10,'Puerto de Hamburgo','Hamburgo'),(11,'Puerto de Amberes','Amberes'),(12,'Puerto de Busan','Busan'),(13,'Puerto de Tianjin','Tianjin'),(14,'Puerto de Santos','Santos');
/*!40000 ALTER TABLE `puertos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rutas`
--

DROP TABLE IF EXISTS `rutas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rutas` (
  `idRutas` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `puerto_origen` int(11) DEFAULT NULL,
  `puerto_destino` int(11) DEFAULT NULL,
  `distancia` varchar(45) DEFAULT NULL,
  `frecuencia_ruta` varchar(45) DEFAULT NULL,
  `estado_ruta` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idRutas`),
  KEY `PuertoOrigenFk_idx` (`puerto_origen`),
  KEY `PuertoDestinoFk_idx` (`puerto_destino`),
  CONSTRAINT `PuertoDestinoFk` FOREIGN KEY (`puerto_destino`) REFERENCES `puertos` (`idPuertos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `PuertoOrigenFk` FOREIGN KEY (`puerto_origen`) REFERENCES `puertos` (`idPuertos`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rutas`
--

LOCK TABLES `rutas` WRITE;
/*!40000 ALTER TABLE `rutas` DISABLE KEYS */;
INSERT INTO `rutas` VALUES (1,'Ruta de Tumaco a Cartagena',1,2,'1000 km','Semanal','Activa'),(2,'Ruta de Tumaco a Barranquilla',1,3,'1200 km','Quincenal','Activa'),(3,'Ruta de Cartagena a Santa Marta',2,4,'800 km','Diaria','Activa'),(4,'Ruta de Santa Marta a Buenaventura',4,5,'1500 km','Quincenal','Activa'),(5,'Ruta de Buenaventura a Long Beach',5,6,'3000 km','Semanal','Activa'),(6,'Ruta de Long Beach a Róterdam',6,7,'7000 km','Semanal','Activa'),(7,'Ruta de Róterdam a Shanghái',7,8,'9000 km','Quincenal','Activa'),(8,'Ruta de Shanghái a Los Ángeles',8,9,'11000 km','Mensual','Activa'),(9,'Ruta de Los Ángeles a Hamburgo',9,10,'8000 km','Semanal','Activa'),(10,'Ruta de Hamburgo a Amberes',10,11,'600 km','Diaria','Activa');
/*!40000 ALTER TABLE `rutas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiquetes`
--

DROP TABLE IF EXISTS `tiquetes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tiquetes` (
  `idtiquete` int(11) NOT NULL AUTO_INCREMENT,
  `idcliente` int(11) DEFAULT NULL,
  `fecha_emision` datetime DEFAULT NULL,
  `fecha_salida` datetime DEFAULT NULL,
  `precio` decimal(9,2) DEFAULT NULL,
  `idbarco` int(11) DEFAULT NULL,
  `fecha_llegada` datetime DEFAULT NULL,
  `idruta` int(11) DEFAULT NULL,
  PRIMARY KEY (`idtiquete`),
  KEY `idcliente_idx` (`idcliente`),
  KEY `idbarco_idx` (`idbarco`),
  KEY `RutaFK_idx` (`idruta`),
  CONSTRAINT `BarcoFk` FOREIGN KEY (`idbarco`) REFERENCES `barco` (`idbarco`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ClienteFK` FOREIGN KEY (`idcliente`) REFERENCES `clientes` (`idcliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `RutaFK` FOREIGN KEY (`idruta`) REFERENCES `rutas` (`idRutas`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiquetes`
--

LOCK TABLES `tiquetes` WRITE;
/*!40000 ALTER TABLE `tiquetes` DISABLE KEYS */;
/*!40000 ALTER TABLE `tiquetes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-26 16:37:52
