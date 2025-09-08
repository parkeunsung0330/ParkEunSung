DROP DATABASE IF EXISTS `mmorpgdb`;

CREATE SCHEMA `mmorpgdb` DEFAULT CHARACTER SET utf8mb4 collate utf8mb4_persian_ci;

-- ALTER SCHEMA `mmorpgdb`  DEFAULT CHARACTER SET utf8mb4  DEFAULT COLLATE utf8mb4_persian_ci ;
USE `mmorpgdb`;

DROP TABLE IF EXISTS `user`;

CREATE TABLE IF NOT EXISTS `user` (
  `uno` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `userid` VARCHAR(20) NOT NULL,
  `userpwd` VARCHAR(60) NOT NULL,
  `uptdate` DATETIME NULL,
  `iptdate` DATETIME NULL,
  PRIMARY KEY (`uno`),
  UNIQUE INDEX `userid_UNIQUE` (`userid` ASC) VISIBLE);
  
  ALTER TABLE `user` ADD COLUMN `eamil` VARCHAR(100) NULL AFTER `userpwd`;
  
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

-- -------------------------------------------------------------------------

INSERT INTO `user`(`userid`,`userpwd`,`eamil`,`uptdate`,`iptdate`)
VALUES("parkes",password("1234"),"pes123@gmail.com",current_timestamp(),current_timestamp());

INSERT INTO `user` (`userid`, `userpwd`, `eamil`, `uptdate`, `iptdate`)
 VALUES ('dsfn', password("1234"), 'adfmadslfk@gmail.com', current_timestamp(), current_timestamp());

select * from `user` where `uno` = 1 or `iptdate` < current_timestamp();
select * from `user` where `userid` = "parkes";
select * from `user` where `iptdate` < current_timestamp() order by `iptdate` desc limit 1,2;

INSERT INTO `user`(`userid`,`userpwd`,`eamil`,`uptdate`,`iptdate`)
VALUES("eunsungpark",password("0330"),"Pes0330@gmail.com",current_timestamp(),current_timestamp());
select * from `user` where `uno` = 3;

UPDATE `mmorpgdb`.`user`
SET `userid` = "abcd",`eamil` = "abcd@gmail.com",`uptdate` = current_timestamp()
WHERE `uno` = 1;

select * from `user`;
-- UPDATE `mmorpgdb`.`user` SET `eamil` = 'abcd1@gmail.com' WHERE (`uno` = '1');

-- delete from `user` where `uno`=1;

-- truncate table `user`;

-------------------------------------------------------------------------

INSERT INTO `character`(`user_uno`,`cname`,`ctribe`,`clv`,`cgender`,`cclass`,`str`,`dex`,`wisd`,`hp`,`mana`,`uptdate`,`iptdate`)
VALUES(1,"Pes","human",20,0,"warrior",20,10,2,100,30,current_timestamp(),current_timestamp());

INSERT INTO `character`(`user_uno`,`cname`,`ctribe`,`clv`,`cgender`,`cclass`,`str`,`dex`,`wisd`,`hp`,`mana`,`uptdate`,`iptdate`)
VALUES(2,"Esp","human",20,1,"wizard",5,5,20,50,100,current_timestamp(),current_timestamp());

INSERT INTO `character`(`user_uno`,`cname`,`ctribe`,`clv`,`cgender`,`cclass`,`str`,`dex`,`wisd`,`hp`,`mana`,`uptdate`,`iptdate`)
VALUES(3,"Spe","ghost",10,1,"shadow",20,1,20,1,100,current_timestamp(),current_timestamp());

-- -------------------------------------------------------------------------
INSERT INTO `mmorpgdb`.`items`(`itname`,`sptritepath`,`uptdate`,`iptdate`)
VALUES("Meat","Sprites/Items/food_meat",current_timestamp(),current_timestamp());

INSERT INTO `mmorpgdb`.`items`(`itname`,`sptritepath`,`uptdate`,`iptdate`)
VALUES("Lighting","Sprites/Items/food_meat",current_timestamp(),current_timestamp());


-- -------------------------------------------------------------------------

INSERT INTO `mmorpgdb`.`inventory`(`character_cno`,`items_itno`,`uptdate`,`iptdate`)
VALUES(1,1,current_timestamp(),current_timestamp());

INSERT INTO `mmorpgdb`.`inventory`(`character_cno`,`items_itno`,`uptdate`,`iptdate`)
VALUES(1,2,current_timestamp(),current_timestamp());

INSERT INTO `mmorpgdb`.`inventory`(`character_cno`,`items_itno`,`uptdate`,`iptdate`)
VALUES(2,1,current_timestamp(),current_timestamp());

INSERT INTO `mmorpgdb`.`inventory`(`character_cno`,`items_itno`,`uptdate`,`iptdate`)
VALUES(2,2,current_timestamp(),current_timestamp());

INSERT INTO `mmorpgdb`.`inventory`(`character_cno`,`items_itno`,`uptdate`,`iptdate`)
VALUES(3,1,current_timestamp(),current_timestamp());

INSERT INTO `mmorpgdb`.`inventory`(`character_cno`,`items_itno`,`uptdate`,`iptdate`)
VALUES(3,2,current_timestamp(),current_timestamp());

SELECT `inno`,`cname`,`clv`,`itname`,`sptritepath`
FROM (
	SELECT `cno`,`cname`,`clv`
    FROM `character`
    where `cno` = 1
)A INNER JOIN (
	SELECT `inno`,`character_cno`,`itname`,`sptritepath`
    FROM `inventory` INNER JOIN `items`
    ON `inventory`.`items_itno` = `items`.`itno`
)B ON A.`cno` = B.`character_cno`;




SELECT *
FROM `character`.`cno` INNER JOIN `inventory`.`character_cno`;


DELETE FROM `inventory` WHERE `items_itno` = 3;
DELETE FROM `items` WHERE `itno` = 3;

--  저장 프로시저 테스트
CALL `mmorpgdb`.`sp_insert_user`("pes","1234", "abcde@abc.com");

CALL `mmorpgdb`.`sp_select_characterbyuno`(1);


