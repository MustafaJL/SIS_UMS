use ums;

insert into campus (campus_name, campus_address, campus_phone_number, campus_fax, 
campus_email, is_deleted) values
('Beirut', 'Ghobeiry, Mount Lebanon Governorate, Lebanon', '+96101111111', 
'+96101111112', 'beirut@usal.edu.lb', false),
('Saida', 'Saida, Lebanon', '+96101111113', 
'+96101111114', 'saida@usal.edu.lb', false),
('Tripoli', 'Tripoli, Lebanon', '+96101111115', 
'+96101111116', 'tripoli@usal.edu.lb', false);

select * from campus;

INSERT INTO blocks (campus_id, block_code, floor_count, room_count, is_deleted)
VALUES (1, 'A', 5, 50, false);

select * from blocks;

insert into education (education_type, is_deleted) values
('Bachelor of Science in Computer Science', false),
('Master of Business Administration', false),
('Associate of Arts in Psychology', false);

select * from education;

insert into positions (position_type, is_deleted) values 
('Advisor', false),
('Instructor', false),
('Student', false),
('Accountant', false);

insert into role (role_name, is_deleted) values 
('Administrator', false),
('Accountant', false),
('Lab Instructor', false);

insert into role (role_name, is_deleted) values ('Student', false);

select * from role;

insert into permissions (permission_name) values ('Read');
insert into permissions (permission_name) values ('Write');
insert into permissions (permission_name) values ('Execute');

-- Insert values into permissions table
insert into role_permission (role_id, permission_id) values
(1, 1),
(2, 2);

insert into status (status, is_deleted) values ('Full Time', false);
insert into status (status, is_deleted) values ('Part Time', false);
insert into status (status, is_deleted) values ('Contract', false);




INSERT INTO users (username, user_password, password_salt,campus_id, first_name, middle_name, last_name,
 mother_name, emergency_contact_name,
 personal_email, university_email, gender, date_of_birth, ssn, city, area, street, near_by, 
 building, floor, marital_status, children_count, blood_type, family_registration, place_of_birth,
 social_security_type, is_deleted)
VALUES
(111, 'password', 'salt password',1, 'John', 'Michael', 'Doe', 'Jane Doe', 'Emergency Contact', 
'john@example.com', 
'john.doe@university.com', 'Male', '1995-05-15', 123456789, 'City', 'Area', 'Street 123', 
'Nearby Place', 'Building A', 5, 'Married', 2, 'A+', '123456', 'Birthplace City', 'Social Security Type'
,false),
(112, 'password', 'salt password',1, 'Jane', 'Marie', 'Smith', 'Mary Smith', 'Emergency Contact', 'jane@example.com',
 'jane.smith@university.com', 'Female', '1998-03-22', 987654321, 'City', 'Area', 'Street 456', 
 'Nearby Place', 'Building B', 3, 'Single', 0, 'B-', '654321', 'Birthplace City', 'Social Security Type',
 false),
(123, 'password', 'salt password',1, 'Robert', 'Lee', 'Johnson', 'Linda Johnson', 'Emergency Contact', 'robert@example.com', 
'robert.johnson@university.com', 'Male', '1990-11-10', 456789012, 'City', 'Area', 'Street 789', 
'Nearby Place', 'Building C', 7, 'Divorced', 1, 'O+', '987654', 'Birthplace City', 
'Social Security Type', false);

INSERT INTO users (username, user_password, password_salt,campus_id, first_name, middle_name, last_name,
 mother_name, emergency_contact_name,
 personal_email, university_email, gender, date_of_birth, ssn, city, area, street, near_by, 
 building, floor, marital_status, children_count, blood_type, family_registration, place_of_birth,
 social_security_type, is_deleted)
VALUES
(1111, 'password', 'salt password',1, 'Hadi', 'Ahmad', 'Soufan', 'Jane Doe', 'Emergency Contact', 
'john@example.com', 
'john.doe@university.com', 'Male', '1995-05-15', 123451789, 'City', 'Area', 'Street 123', 
'Nearby Place', 'Building A', 5, 'Married', 2, 'A+', '123456', 'Birthplace City', 'Social Security Type'
,false);

select * from users;

INSERT INTO user_education (user_id, education_id, education_name, from_date, to_date, branch, major_name, date_of_graduation, education_certificate, is_deleted)
VALUES
(1, 1, 'High School', '2010-09-01', '2014-06-30', 'HS', 'Science', '2014-06-30', 'High School Diploma', false),
(1, 2, 'Bachelor', '2014-09-01', '2018-06-30', 'BS', 'Computer Science', '2018-06-30', 'Bachelor\'s Degree in Computer Science', false),
(2, 1, 'High School', '2011-09-01', '2015-06-30', 'HS', 'Arts', '2015-06-30', 'High School Diploma', false);

 
INSERT INTO user_occupation (user_id, occupation_title, responsibilities, employed_since,
 name_of_company, is_deleted)
VALUES (1, 'Software Engineer', 'Developing software applications', '2020-01-15', 'TechCorp',
 false);

insert into offices (campus_id, office_name, manager_user_id, phone, email, 
office_room_number, is_deleted)
values
('1', 'Human Resourse', '1', '+96101111117', 'hr@usal.edu.lb', 'A1-1', false),
('2', 'Accounting', '2', '+96101111118', 'accounting@usal.edu.lb', 'A1-2', false),
('1', 'Student Affier', '2', '+96101111118', 'accounting@usal.edu.lb', 'A1-2', false);

insert into offices (campus_id, office_name, manager_user_id, phone, email, 
office_room_number, is_deleted)
values
('1', 'Student Affier', '2', '+96101111118', 'accounting@usal.edu.lb', 'A1-2', false);

INSERT INTO faculty (campus_id, dean_user_id, faculty_name, faculty_phone_number,
 faculty_uni_email, is_deleted)
VALUES (1, 1, 'Faculty of Art and Science', '123-456-7890', 'faculty1@usal.edu.lb',
 false);
 
 INSERT INTO faculty (campus_id, dean_user_id, faculty_name, faculty_phone_number,
 faculty_uni_email, is_deleted)
VALUES (1, 2, 'Faculty of Business', '123-456-7890', 'faculty2@usal.edu.lb',
 false);
 
 INSERT INTO faculty (campus_id, dean_user_id, faculty_name, faculty_phone_number,
 faculty_uni_email, is_deleted)
VALUES (1, 2, 'Faculty of Education', '123-456-7810', 'faculty3@usal.edu.lb',
 false);

select * from faculty;

INSERT INTO department (faculty_id, department_name, department_phone_number, department_uni_email, is_deleted)
VALUES (1, 'Computer Science Department', '123-456-7890', 'cs.department@example.com', false);

INSERT INTO department (faculty_id, department_name, department_phone_number, department_uni_email, is_deleted)
VALUES (2, 'Accounting and Finance Department', '123-456-7891', 'accounting.department@example.com', false);

INSERT INTO department (faculty_id, department_name, department_phone_number, department_uni_email, is_deleted)
VALUES (3, 'Special Education', '123-456-7893', 'education.department@example.com', false);

delete from department;

select * from department;
select * from students;
select * from major;

insert into students(student_id, user_id, has_official_body, is_deleted) values
('1121050', 3, false, false);

insert into students(student_id, user_id, has_official_body, is_deleted) values
('1121010', 4, false, false);

select * from users;
select * from students;

INSERT INTO major (department_id, major_name, university_requirements, department_requirements, concnetration_requirements, elective_requirements, is_deleted)
VALUES (1, 'Computing and Programming', 12, 48, 18, 15, false);

INSERT INTO major (department_id, major_name, university_requirements, department_requirements, concnetration_requirements, elective_requirements, is_deleted)
VALUES (2, 'Accounting and Finance', 12, 48, 18, 15, false);

INSERT INTO major (department_id, major_name, university_requirements, department_requirements, concnetration_requirements, elective_requirements, is_deleted)
VALUES (3, 'Special Education', 12, 48, 18, 15, false);

select * from major;

INSERT INTO student_major (student_id, major_id, is_deleted) values
('1121050', 1, false);

INSERT INTO student_major (student_id, major_id, is_deleted) values
('1121010', 3, false);


INSERT INTO courses (campus_id, department_id, is_core_course, course_name, course_code, credits, is_deleted)
VALUES (1, 1, true, 'Introduction to Programming', 'CS101', 3, false);

INSERT INTO courses (campus_id, department_id, is_core_course, course_name, course_code, credits, is_deleted)
VALUES (1, 1, true, 'Computer Science Overview', 'CS102', 1, false);

INSERT INTO courses (campus_id, department_id, is_core_course, course_name, course_code, credits, is_deleted)
VALUES (1, 1, true, 'Calculus', 'CS103', 3, false);

INSERT INTO courses (campus_id, department_id, is_core_course, course_name, course_code, credits, is_deleted)
VALUES (1, 1, false, 'Arabic', 'ARAB104', 2, false);

INSERT INTO courses (campus_id, department_id, is_core_course, course_name, course_code, credits, is_deleted)
VALUES (1, 2, false, 'Accounting', 'Acc101', 3, false);

INSERT INTO courses (campus_id, department_id, is_core_course, course_name, course_code, credits, is_deleted)
VALUES (1, 1, false, 'Arabic', 'Acc101', 3, false),
(1, 2, false, 'Accounting', 'Acc101', 3, false),
(1, 2, false, 'Accounting', 'Acc101', 3, false),
(1, 2, false, 'Accounting', 'Acc101', 3, false),
(1, 2, false, 'Accounting', 'Acc101', 3, false);

INSERT INTO courses (campus_id, department_id, is_core_course, course_name, course_code, credits, is_deleted)
VALUES (1, 3, false, 'Eng', 'Acc102', 3, false),
(1, 3, false, 'Teach', 'Acc103', 3, false),
(1, 3, false, 'English', 'Acc104', 3, false),
(1, 3, false, 'Emotion', 'Acc105', 3, false),
(1, 3, false, 'Commu', 'Acc106', 3, false);

select * from courses;
delete from courses;

delete from courses where campus_id = 2;

INSERT INTO academic_year (academic_year_range, is_deleted)
VALUES ('2023-2024', false);

INSERT INTO semester_code (semester_code_name, is_deleted)
VALUES ('Fall 2023/2024', false);


INSERT INTO semester (academic_year_id, semester_name, semester_code_id, is_course_withdraw_withrefund_end_date, is_semester_withdraw_withrefund_end_date, is_registration_start_date, is_registration_end_date, is_deleted)
VALUES (1, 'Fall', 1, false, false, false, false, false);


select * from courses;

INSERT INTO course_offering (campus_id, course_id, semester_id, section, is_deleted)
VALUES (1, 12, 1, 'A', false);
INSERT INTO course_offering (campus_id, course_id, semester_id, section, is_deleted)
VALUES (1, 13, 1, 'A', false);
INSERT INTO course_offering (campus_id, course_id, semester_id, section, is_deleted)
VALUES (1, 14, 1, 'A', false);
INSERT INTO course_offering (campus_id, course_id, semester_id, section, is_deleted)
VALUES (1, 15, 1, 'A', false);
INSERT INTO course_offering (campus_id, course_id, semester_id, section, is_deleted)
VALUES (1, 16, 1, 'A', false);

INSERT INTO course_offering (campus_id, course_id, semester_id, section, is_deleted)
VALUES (1, 17, 1, 'A', false),
(1, 18, 1, 'A', false),
(1, 19, 1, 'A', false),
(1, 20, 1, 'A', false),
(1, 21, 1, 'A', false);

select * from course_offering;
delete from course_offering;

INSERT INTO student_courses (student_id, course_offering_id, course_status, is_delete)
VALUES ('1121050',7, 'Registered', false);
INSERT INTO student_courses (student_id, course_offering_id, course_status, is_delete)
VALUES ('1121050', 8, 'Registered', false);
INSERT INTO student_courses (student_id, course_offering_id, course_status, is_delete)
VALUES ('1121050', 9, 'Registered', false);
INSERT INTO student_courses (student_id, course_offering_id, course_status, is_delete)
VALUES ('1121050', 10, 'Registered', false);
INSERT INTO student_courses (student_id, course_offering_id, course_status, is_delete)
VALUES ('1121050', 11, 'Registered', false);

INSERT INTO student_courses (student_id, course_offering_id, course_status, is_delete)
VALUES ('1121010', 12, 'Registered', false),
('1121010', 13, 'Registered', false),
('1121010', 14, 'Registered', false),
('1121010', 15, 'Registered', false),
('1121010', 16, 'Registered', false),
('1121010', 11, 'Registered', false),
('1121010', 7, 'Registered', false);

call get_all_student_courses();

delete from student_courses;

INSERT INTO student_courses (student_id, course_offering_id, course_status, finalgrade,
 lettergrade, is_delete)
VALUES ('1121050', 7, 'Passed', 95.5, 'A', false),
('1121050', 8, 'Passed', 95.5, 'A', false),
('1121050', 9, 'Passed', 95.5, 'A', false),
('1121050', 10, 'Passed', 95.5, 'A', false);

INSERT INTO student_courses (student_id, course_offering_id, course_status, finalgrade,
 lettergrade, is_delete)
VALUES ('1121050', 11, 'Passed', 95.5, 'A', false);

select * from student_courses;

delete from student_courses;

INSERT INTO currency (currency_name, is_deleted)
VALUES ('Dollar', false);

INSERT INTO currency (currency_name, is_deleted)
VALUES ('Lebanese', false);

INSERT INTO department_course_cost (semester_id, department_id, currency_id, amount_cost, is_deleted)
VALUES (1, 1, 1, 25, false);
INSERT INTO department_course_cost (semester_id, department_id, currency_id, amount_cost, is_deleted)
VALUES (1, 1, 2, 750000, false);

INSERT INTO department_course_cost (semester_id, department_id, currency_id, amount_cost, is_deleted)
VALUES (1, 2, 1, 20, false);
INSERT INTO department_course_cost (semester_id, department_id, currency_id, amount_cost, is_deleted)
VALUES (1, 2, 2, 650000, false);

INSERT INTO department_course_cost (semester_id, department_id, currency_id, amount_cost, is_deleted)
VALUES (1, 3, 1, 15, false);
INSERT INTO department_course_cost (semester_id, department_id, currency_id, amount_cost, is_deleted)
VALUES (1, 3, 2, 550000, false);

select * from department_course_cost;

delete from department_course_cost;

CALL get_student_total_courses_cost('1121050');

CALL get_student_total_courses_cost('1121010');

select * from student_fees;

delete from student_fees;

INSERT INTO transcation_type (transcation_type_name, is_deleted)
VALUES ('Payment', false);

INSERT INTO transacation_way (transaction_way_name, is_deleted)
VALUES ('Cash', false);

delete from transcation_type;

INSERT INTO scholarships (scholarship_type, percentage_in_dollar, percentage_in_lebanese, is_deleted)
VALUES ('Financial Aid', 10.00, 35.00, false);

INSERT INTO scholarships (scholarship_type, percentage_in_dollar, percentage_in_lebanese, is_deleted)
VALUES ('Sports', 15.00, 55.00, false);

INSERT INTO student_scholarships (student_id, scholarship_id, is_deleted)
VALUES ('1121050', 1, false);

INSERT INTO student_scholarships (student_id, scholarship_id, is_deleted)
VALUES ('1121010', 2, false);



