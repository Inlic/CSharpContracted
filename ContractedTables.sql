CREATE TABLE IF NOT EXISTS jobs(
  id int AUTO_INCREMENT NOT NULL,
  location VARCHAR(255),
  description VARCHAR(255),
  contactinfo VARCHAR(255),
  startdate VARCHAR(255),

  PRIMARY KEY (id)
);

INSERT INTO jobs(location, description, contactinfo, startdate)
VALUES("Shelbyville", "Need to Replace a Lemon Tree", "888-3456", "1985-10-15");

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

SELECT * FROM contractors;


CREATE TABLE IF NOT EXISTS reviews(
  id int AUTO_INCREMENT NOT NULL,
  title VARCHAR(255),
  body VARCHAR(255),
  rating VARCHAR(255),
  date DATE,
  contractorid int,
  PRIMARY KEY (id)
);

INSERT INTO reviews(title, body, rating, date, contractorid)
VALUES("He was slow but...", "Very thorough job from Slow Jim", "Five out of Five","2019-10-10", 1);

SELECT * FROM reviews;



CREATE TABLE IF NOT EXISTS bids(
  id int AUTO_INCREMENT NOT NULL,
  jobid int,
  contractorid int,
  bidrate decimal(6,2),

  PRIMARY KEY (id)
);

INSERT INTO bids(jobid, contractorid, bidrate)
VALUES(1, 1, 4.50);

SELECT * FROM bids;






-- INSERT INTO jobs(location, description, contact)
-- VALUES("Shelbyville", "New Statue", "888-3456")

-- INSERT INTO contractors(name, address, contact, skills)
-- VALUES("Slow Jim", "1234 Fake Street", "999-3456", "Carpentry, Electricity, Plumbing")

-- INSERT INTO contractors(name, address, contact, skills)
-- VALUES("Speedy Pete", "9946 Fake Street", "345-9675", "Carpentry, Demolitions, Plumbing")


--SELECT * FROM jobs