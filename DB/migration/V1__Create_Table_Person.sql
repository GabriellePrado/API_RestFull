
CREATE TABLE IF NOT EXISTS `pessoas` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(80) NOT NULL,
  `Sobrenome` varchar(80) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Genero` varchar(6) NOT NULL,
  PRIMARY KEY (`Id`)
)