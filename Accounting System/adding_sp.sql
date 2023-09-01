use ums;

call add_new_official_body(3, 'NGO');

call add_new_application_form(1, '1121050', '2023-09-01', 'Scholarship', 'Pending', '2023-09-02', 'Additional details...');

CALL add_new_financial_agreement(1, '1121050', '2023-09-01', 'Agreement details...', '2023-09-01', '2023-12-31', true);

CALL add_new_financial_statement(1, '1121050', 100.00, 150000.00, 50.00, 75000.00, 50.00, 75000.00, true);

CALL add_new_fee_type('Tuition Fee', 2000.00, 2500000.00, true);

CALL add_new_donor(1);

CALL add_new_scholarship('Merit Scholarship', 10.00, 15.00);

CALL add_new_donation(1, 2, 100.00, 150000.00, 'Supporting scholarship program');

CALL add_new_student_fee_type(4, 'NSSF', 0, 4000000.00, false);
CALL add_new_student_fee_type(4, 'Registration Fee', 150.00, 0, false);
CALL add_new_student_fee_type(4, 'Courses Fee', 285.00, 8700000.00, true);

CALL add_new_student_fee_type(3, 'NSSF', 0, 4000000.00, false);
CALL add_new_student_fee_type(3, 'Registration Fee', 150.00, 0, false);
CALL add_new_student_fee_type(3, 'Courses Fee', 306.00, 5602500.00, true);

select * from student_fees;

delete from student_fees;

call add_new_account_type('Students');
call add_new_account_type('University');

select * from account_type;

CALL update_accounts_from_fees(4, 1);
CALL update_accounts_from_fees(3, 1);

CALL update_accounts_from_fees(2, 2);

call add_new_transaction_type('Payment');

call add_new_transaction_way('Cash');

select * from accounts;
delete from accounts;

select * from transcation_type;
select * from transacation_way;

CALL process_transaction(1, 1, 39, 41, 35.00, 700000.00);

CALL process_transaction(1, 1, 40, 41, 56.00, 602500.00);

select * from transactions;

call add_new_supplier('xxx', 'xxx', '434343', false);