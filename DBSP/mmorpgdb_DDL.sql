-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mmorpgdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mmorpgdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mmorpgdb` DEFAULT CHARACTER SET utf8 ;
USE `mmorpgdb` ;

-- -----------------------------------------------------
-- Table `mmorpgdb`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mmorpgdb`.`user` (
  `uno` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `userid` VARCHAR(20) NOT NULL,
  `userpwd` VARCHAR(60) NOT NULL,
  `uptdate` DATETIME NULL,
  `iptdate` DATETIME NULL,
  PRIMARY KEY (`uno`),
  UNIQUE INDEX `userid_UNIQUE` (`userid` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mmorpgdb`.`character`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mmorpgdb`.`character` (
  `cno` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `user_uno` INT UNSIGNED NOT NULL,
  `cname` VARCHAR(45) NOT NULL,
  `ctribe` VARCHAR(45) NOT NULL,
  `clv` INT NOT NULL,
  `cgender` BIT(1) NOT NULL,
  `cclass` VARCHAR(45) NOT NULL,
  `str` INT NOT NULL,
  `dex` INT NOT NULL,
  `wisd` INT NOT NULL,
  `hp` INT NOT NULL,
  `mana` INT NOT NULL,
  `uptdate` DATETIME NULL,
  `iptdate` DATETIME NULL,
  PRIMARY KEY (`cno`),
  INDEX `fk_charactor_user_idx` (`user_uno` ASC) VISIBLE,
  CONSTRAINT `fk_charactor_user`
    FOREIGN KEY (`user_uno`)
    REFERENCES `mmorpgdb`.`user` (`uno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mmorpgdb`.`items`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mmorpgdb`.`items` (
  `itno` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `itdata` JSON NOT NULL,
  `itname` VARCHAR(45) NOT NULL,
  `sptritepath` VARCHAR(300) NULL,
  `uptdate` DATETIME NULL,
  `iptdate` DATETIME NULL,
  PRIMARY KEY (`itno`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mmorpgdb`.`inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mmorpgdb`.`inventory` (
  `inno` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `character_cno` INT UNSIGNED NOT NULL,
  `items_itno` INT UNSIGNED NOT NULL,
  `uptdate` DATETIME NULL,
  `iptdate` DATETIME NULL,
  PRIMARY KEY (`inno`),
  INDEX `fk_inventory_character1_idx` (`character_cno` ASC) VISIBLE,
  INDEX `fk_inventory_items1_idx` (`items_itno` ASC) VISIBLE,
  CONSTRAINT `fk_inventory_character1`
    FOREIGN KEY (`character_cno`)
    REFERENCES `mmorpgdb`.`character` (`cno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_inventory_items1`
    FOREIGN KEY (`items_itno`)
    REFERENCES `mmorpgdb`.`items` (`itno`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
