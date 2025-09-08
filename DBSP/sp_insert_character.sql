DROP PROCEDURE IF EXISTS `sp_insert_character`;

DELIMITER $$

CREATE PROCEDURE `sp_insert_character`(
_UNO INT,
_CNAME VARCHAR(45),
_CTRIBE VARCHAR(45),
_CLV INT,
_CGENDER TINYINT,
_CCLASS VARCHAR(45),
_STR INT,
_DEX INT,
_WISD INT,
_HP INT,
_MANA INT
)
BEGIN
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @errstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @errtext = MESSAGE_TEXT;
        SET @errstmt := "INSERT INTO `ErrorProcedure`(`errLocate`,`errNum`,`errCode`,`errMsg`) VALUES('sp_insert_character',?,?,?)";
        PREPARE stmt FROM @errstmt;
        EXECUTE stmt USING @errno,@errstate,@errtext;
        DEALLOCATE PREPARE stmt;
        ROLLBACK;
        SET @_errcode = "E0500";
	END;
    
    
    
	SET @_errcode = "E0000";
    
		START TRANSACTION;
			SET @stmt := "INSERT INTO `character`(`user_uno`,`cname`,`ctribe`,`clv`,`cgender`,`cclass`,`str`,`dex`,`wisd`,`hp`,`mana`,`uptdate`,`iptdate`)
			VALUES(?,?,?,?,?,?,?,?,?,?,?,current_timestamp(),current_timestamp())";
			PREPARE stmt FROM @stmt;
			SET @a := _UNO,@b := _CNAME, @c := _CTRIBE, @d :=_CLV, @e :=_CGENDER, @f :=_CCLASS, @g :=_STR, @h :=_DEX, @i :=_WISD, @j :=_HP, @k :=_MANA;
			EXECUTE stmt USING @a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k;
			DEALLOCATE PREPARE stmt;
		COMMIT;
 
        SELECT @_errcode AS `errorcode`, last_insert_id() as `cno`;


END$$

DELIMITER ;