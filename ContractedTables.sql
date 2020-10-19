CREATE TABLE IF NOT EXISTS jobs(
  id int AUTO_INCREMENT NOT NULL,
  location VARCHAR(255),
  description VARCHAR(255),
  contact VARCHAR(255),

  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS contractors(
  id int AUTO_INCREMENT NOT NULL,
  name VARCHAR(255),
  address VARCHAR(255),
  contact VARCHAR(255),
  skills VARCHAR(255),

  PRIMARY KEY (id)
);

INSERT INTO jobs(location, description, contact)
VALUES("Shelbyville", "New Statue", "888-3456")

INSERT INTO contractors(name, address, contact, skills)
VALUES("Slow Jim", "1234 Fake Street", "999-3456", "Carpentry, Electricity, Plumbing")

INSERT INTO contractors(name, address, contact, skills)
VALUES("Speedy Pete", "9946 Fake Street", "345-9675", "Carpentry, Demolitions, Plumbing")


SELECT * FROM contractors