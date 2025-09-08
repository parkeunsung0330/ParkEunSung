-- -----------------------------------------------------
-- Table `sakila`.`ErrorProcedure`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mmorpgdb`,`ErrorProcedure` ;

CREATE TABLE `ErrorProcedure` (
  `errID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `errLocate` varchar(64) DEFAULT NULL,
  `errNum` int(11) DEFAULT NULL,
  `errCode` char(5) DEFAULT NULL,
  `errMsg` text,
  `iptdate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`errID`)
) ENGINE=InnoDB;