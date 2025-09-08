DROP PROCEDURE IF EXISTS `sp_insert_user`;

DELIMITER $$

CREATE PROCEDURE `sp_insert_user`(
_USERID VARCHAR(20),
_USERPWD VARCHAR(60),
_EMAIL VARCHAR(100)
)
BEGIN
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @errstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @errtext = MESSAGE_TEXT;
        SET @errstmt := "INSERT INTO `ErrorProcedure`(`errLocate`,`errNum`,`errCode`,`errMsg`) VALUES('sp_insert_user',?,?,?)";
        PREPARE stmt FROM @errstmt;
        EXECUTE stmt USING @errno,@errstate,@errtext;
        DEALLOCATE PREPARE stmt;
        ROLLBACK;
	END;
    
    SET @_cnt = 0;
	SELECT COUNT(0) INTO @_cnt FROM `user` WHERE `userid` = _USERID AND `userpwd` = password(_USERPWD);
    
	IF @_cnt = 0 THEN
		START TRANSACTION;
			SET @stmt := "INSERT INTO `user`(`userid`,`userpwd`,`eamil`,`uptdate`,`iptdate`)
			VALUES(?,?,?,current_timestamp(),current_timestamp())";      
			PREPARE stmt FROM @stmt;
			SET @a := _USERID,@b := password(_USERPWD), @c := _EMAIL;
			EXECUTE stmt USING @a,@b,@c;
			DEALLOCATE PREPARE stmt;
		COMMIT;
	END IF;
    
    SELECT `uno` FROM `user` WHERE `userid` = _USERID AND `userpwd` = password(_USERPWD);

END$$

DELIMITER ;