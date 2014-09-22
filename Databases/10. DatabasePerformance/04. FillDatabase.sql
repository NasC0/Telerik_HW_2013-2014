DELIMITER $$
CREATE PROCEDURE insert_test_data()
BEGIN
	SET @Rows = 0;
	SET @Min = '1990-01-01';
	SET @Max = NOW();

	START TRANSACTION;
	WHILE @Rows < 1000000
	DO
		SET @date = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @Min, @Max)), @Min);
		SET @text = CONCAT('Text', @Rows);
		INSERT INTO Logs
		(LogText, LogDate)
		VALUES (@text, @date);

		SET @Rows = @Rows + 1;
	END WHILE;
	COMMIT;
END$$
DELIMITER ;

CALL insert_test_data()