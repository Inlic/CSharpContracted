-- DATA RESET 

DROP TABLE profiles;
DROP TABLE bids;
DROP TABLE jobs;
DROP TABLE reviews;
DROP TABLE contractors;

-- New Tables

CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  name VARCHAR(255),
  picture VARCHAR(255),

  PRIMARY KEY (id)
);

INSERT INTO profiles(id, email, name, picture)
VALUES("test", "test@test.com", "Jim Test", "Smiley.jpg");

SELECT * FROM profiles;


CREATE TABLE IF NOT EXISTS jobs(
  id int AUTO_INCREMENT NOT NULL,
  location VARCHAR(255),
  description VARCHAR(255),
  contactinfo VARCHAR(255),
  startdate VARCHAR(255),
  creatorId VARCHAR(255) NOT NULL,

  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
  References profiles(id)
  ON DELETE CASCADE
);

INSERT INTO jobs(location, description, contactinfo, startdate, creatorId)
VALUES("Shelbyville", "Need to Replace a Lemon Tree", "888-3456", "1985-10-15","test");
INSERT INTO jobs(location, description, contactinfo, startdate, creatorId)
VALUES("Misty Bog", "Burn the Vegetation and Pave the Roads", "888-3456", "1995-11-22", "test");

SELECT * FROM jobs;


CREATE TABLE IF NOT EXISTS contractors(
  id int AUTO_INCREMENT NOT NULL,
  name VARCHAR(255),
  contacttype ENUM("Call","Text","Email"),
  contactinfo VARCHAR(255),

  PRIMARY KEY (id)
);

INSERT INTO contractors(name, contacttype, contactinfo)
VALUES("Slow Jim", "Email", "slowJimmy@Jimbo.jims");
INSERT INTO contractors(name, contacttype, contactinfo)
VALUES("Fast Pete", "Email", "quickPetey@Jimbo.jims");

SELECT * FROM contractors;


CREATE TABLE IF NOT EXISTS reviews(
  id int AUTO_INCREMENT NOT NULL,
  title VARCHAR(255),
  body VARCHAR(255),
  rating VARCHAR(255),
  date DATE,
  contractorid int,
  creatorId VARCHAR(255) NOT NULL,
  
  PRIMARY KEY (id),
  INDEX(contractorid),

  FOREIGN KEY (contractorid)
  REFERENCES contractors (id)
  ON DELETE CASCADE,

  FOREIGN KEY (creatorId)
  References profiles(id)
  ON DELETE CASCADE
);

INSERT INTO reviews(title, body, rating, date, contractorid, creatorId)
VALUES("He was slow but...", "Very thorough job from Slow Jim", "Five out of Five","2019-10-10", 1, "test");
INSERT INTO reviews(title, body, rating, date, contractorid, creatorId)
VALUES("Too fast", "Got done quickly, but left a mess", "Three out of Five","2017-12-13", 2, "test");

SELECT * FROM reviews;



CREATE TABLE IF NOT EXISTS bids
(
  id int AUTO_INCREMENT NOT NULL,
  jobid int,
  contractorid int,
  bidrate decimal(6,2),

  PRIMARY KEY (id),

  FOREIGN KEY (jobid)
  REFERENCES jobs (id)
  ON DELETE CASCADE,

  FOREIGN KEY (contractorid)
  REFERENCES contractors (id)
  ON DELETE CASCADE
);

INSERT INTO bids(jobid, contractorid, bidrate)
VALUES(2, 1, 4.50);

INSERT INTO bids(jobid, contractorid, bidrate)
VALUES(3, 1, 9.50);

SELECT * FROM bids;






-- INSERT INTO jobs(location, description, contact)
-- VALUES("Shelbyville", "New Statue", "888-3456")

-- INSERT INTO contractors(name, address, contact, skills)
-- VALUES("Slow Jim", "1234 Fake Street", "999-3456", "Carpentry, Electricity, Plumbing")

-- INSERT INTO contractors(name, address, contact, skills)
-- VALUES("Speedy Pete", "9946 Fake Street", "345-9675", "Carpentry, Demolitions, Plumbing")


--SELECT * FROM jobs