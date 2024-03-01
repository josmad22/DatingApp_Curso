BEGIN TRANSACTION;

ALTER TABLE "User" ADD "Email" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240228165051_AddEmail_To_UserModel', '7.0.16');

COMMIT;

