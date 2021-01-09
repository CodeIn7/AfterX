CREATE TABLE "user" (
  id SERIAL PRIMARY KEY,
  email varchar UNIQUE NOT NULL,
  password varchar NOT NULL
);

CREATE TABLE userAttribues (
  id SERIAL PRIMARY KEY,
  userId int UNIQUE NOT NULL,
  firstname varchar NOT NULL,
  lastname varchar NOT NULL,
  gender character CHECK(gender='M' OR gender='F'),
  yearOfBirth date,
  telephone varchar
);

CREATE TABLE "role" (
  id SERIAL PRIMARY KEY,
  name varchar UNIQUE NOT NULL
);

CREATE TABLE "role_user" (
  userId int NOT NULL,
  roleId int NOT NULL,
  PRIMARY KEY (userId, roleId)
);

CREATE TABLE "club" (
  id SERIAL PRIMARY KEY,
  name varchar NOT NULL,
  addressId int,
  UNIQUE("name",addressId)
);

CREATE TABLE "city" (
  id SERIAL PRIMARY KEY,
  countryId int NOT NULL,
  name varchar NOT NULL,
  zip numeric,
  unique(countryId,"name")
);

CREATE TABLE "country" (
  id SERIAL PRIMARY KEY,
  name varchar UNIQUE NOT NULL
);

CREATE TABLE "address" (
  id SERIAL PRIMARY KEY,
  cityId int NOT NULL,
  street varchar NOT NULL,
  number varchar,
  unique(cityId, street, "number")
);

CREATE TABLE "drink_club" (
  drinkId int,
  clubId int,
  price numeric NOT NULL CHECK(price>0),
  PRIMARY KEY (drinkId, clubId)
);

CREATE TABLE "drink" (
  id SERIAL PRIMARY KEY,
  quantity numeric NOT NULL,
  name varchar NOT NULL,
  drinkTypeId int NOT NULL,
  unique(quantity,"name",drinkTypeId)
);

CREATE TABLE "table" (
  id SERIAL PRIMARY KEY,
  number SERIAL,
  tableTypeId int NOT NULL,
  clubId int NOT NULL,
  capacity smallint CHECK(capacity>=0),
  minNoBottles smallint NOT NULL CHECK(minNoBottles>=0),
  unique("number",clubId)
);

CREATE TABLE "tableType" (
  id SERIAL PRIMARY KEY,
  name varchar UNIQUE NOT NULL
);

CREATE TABLE "drinkType" (
  id SERIAL PRIMARY KEY,
  name varchar UNIQUE NOT NULL
);

CREATE TABLE "reservation" (
  id SERIAL PRIMARY KEY,
  tableId int NOT NULL,
  userId int NOT NULL,
  reservationDate date NOT NULL,
  numberOfPeople smallint NOT NULL,
  unique(tableId,userId,reservationDate)
);

CREATE TABLE "order" (
  id SERIAL PRIMARY KEY,
  tableId int NOT NULL,
  reservationId int NOT NULL,
  _note varchar,
  time time NOT NULL,
  unique(tableId,reservationId,time),
  active boolean
);

CREATE TABLE "order_drink" (
  orderId int NOT NULL,
  drinkId int NOT NULL,
  noBottles smallint NOT NULL,
  PRIMARY KEY (orderId, drinkId)
);

CREATE TABLE "package_drink" (
  packageId int NOT NULL,
  drinkId int NOT NULL,
  noBottles smallint NOT NULL,
  PRIMARY KEY (packageId, drinkId)
);

CREATE TABLE "package" (
  id SERIAL PRIMARY KEY,
  name varchar UNIQUE NOT NULL,
  price numeric NOT NULL
);

CREATE TABLE "review" (
  id SERIAL PRIMARY KEY,
  clubId int NOT NULL,
  userId int NOT NULL,
  date date NOT NULL,
  desciption varchar,
  grade smallint,
  unique(clubId,userId,date)
);

CREATE TABLE "event" (
  id SERIAL PRIMARY KEY,
  clubId int NOT NULL,
  _date date,
  description varchar,
  price numeric,
  active boolean
);

ALTER TABLE userAttribues ADD FOREIGN KEY (userId) REFERENCES "user"(id) ON DELETE CASCADE;

ALTER TABLE role_user ADD FOREIGN KEY (roleId) REFERENCES role (id) ON DELETE CASCADE;

ALTER TABLE role_user ADD FOREIGN KEY (userId) REFERENCES userAttribues (userId) ON DELETE CASCADE;

ALTER TABLE club ADD FOREIGN KEY (addressId) REFERENCES address (id) ON DELETE SET NULL;

ALTER TABLE address ADD FOREIGN KEY (cityId) REFERENCES city (id) ON DELETE CASCADE;

ALTER TABLE city ADD FOREIGN KEY (countryId) REFERENCES country (id)  ON DELETE CASCADE;

ALTER TABLE event ADD FOREIGN KEY (clubId) REFERENCES club (id) ON DELETE CASCADE;

ALTER TABLE "table" ADD FOREIGN KEY (clubId) REFERENCES club (id) ON DELETE CASCADE;

ALTER TABLE reservation ADD FOREIGN KEY (tableId) REFERENCES "table" (id);

ALTER TABLE reservation ADD FOREIGN KEY (userId) REFERENCES "user"(id) ON DELETE CASCADE;

ALTER TABLE "order" ADD FOREIGN KEY (reservationId) REFERENCES reservation (id) ON DELETE CASCADE;

ALTER TABLE order_drink ADD FOREIGN KEY (orderId) REFERENCES "order" (id) ON DELETE CASCADE;

ALTER TABLE order_drink ADD FOREIGN KEY (drinkId) REFERENCES drink (id) ON DELETE CASCADE;

ALTER TABLE drink_club ADD FOREIGN KEY (drinkId) REFERENCES drink (id) ON DELETE CASCADE;

ALTER TABLE drink_club ADD FOREIGN KEY (clubId) REFERENCES club (id) ON DELETE CASCADE;

ALTER TABLE review ADD FOREIGN KEY (clubId) REFERENCES club (id) ON DELETE CASCADE;

ALTER TABLE review ADD FOREIGN KEY (userId) REFERENCES "user"(id) ON DELETE CASCADE;

ALTER TABLE "table" ADD FOREIGN KEY (tabletypeId) REFERENCES "tableType"(id);

ALTER TABLE drink ADD FOREIGN KEY (drinkTypeId) REFERENCES "drinkType" (id);

ALTER TABLE package_drink ADD FOREIGN KEY (packageId) REFERENCES package (id) ON DELETE CASCADE;

ALTER TABLE package_drink ADD FOREIGN KEY (drinkId) REFERENCES drink (id) ON DELETE CASCADE;

ALTER TABLE "order" ADD FOREIGN KEY (tableId) REFERENCES "table"(id) ON DELETE CASCADE;

