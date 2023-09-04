use ums;

alter table users
add column username int unique;

alter table semester_code
modify column semester_code_name varchar(20);

alter table student_courses
modify column finalgrade decimal(5,2);

alter table courses
drop column major_id;

alter table courses
add column department_id int not null;

alter table courses
add constraint fk_courses_department_course_cost_id
foreign key(department_id) 
references department(department_id) on delete cascade on update cascade;

alter table financial_statement
modify column payments_amount_dollar decimal(5,2) not null;

alter table financial_statement
modify column total_amount_dollar decimal(5,2) not null;

alter table financial_statement
modify column remaining_amount_dollar decimal(5,2) not null;

alter table fee_type
modify column  amount_to_pay_dollar decimal(10,2);

alter table fee_type
modify column  amount_to_pay_lebanese decimal(15,2);

alter table donations
modify column donation_amount_dollar decimal(5,2);

alter table donations
modify column donation_amount_lebanese decimal(15, 2);

alter table transactions
modify column amount_to_pay_dollar decimal(5,2);

alter table transactions
modify column amount_to_pay_lebanese decimal(15,2);

ALTER TABLE fee_type RENAME student_fees; 

alter table student_fees
add column user_id int not null;

alter table student_fees
modify column amount_to_pay_lebanese decimal(15,2);

SET FOREIGN_KEY_CHECKS=0;
alter table student_fees
add constraint fk_student_fees_user_id
foreign key(user_id) references users(user_id) on delete cascade on update cascade;
SET FOREIGN_KEY_CHECKS=1;

alter table accounts
modify column need_to_pay_dollar decimal(16,2);

alter table accounts
modify column need_to_purchase_dollar decimal(16,2);

alter table transactions
modify column amount_to_pay_dollar decimal(5,2);

alter table transactions
modify column amount_to_pay_lebanese decimal(15,2);

alter table application_form
drop column processing_date;

alter table application_form
modify status varchar(255);