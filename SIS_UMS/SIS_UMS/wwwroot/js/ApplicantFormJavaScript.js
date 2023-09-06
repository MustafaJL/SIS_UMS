    document.addEventListener("DOMContentLoaded", function () {
        const sociallySecuredRadios = document.querySelectorAll('input[name="socially_secured"]');
        const ssnField = document.getElementById('ssnField');
        const socialSecurityType = document.getElementById('social_security_type');

        sociallySecuredRadios.forEach(radio => {
            radio.addEventListener("change", function () {
                if (this.value === 'yes') {
                    ssnField.style.display = "block";
                    socialSecurityType.style.display = "block";
                } else {
                    ssnField.style.display = "none";
                    socialSecurityType.style.display = "none";
                    document.querySelector('input[name="social_security_type"]:checked').checked = false;
                    document.getElementById('ssn').value = '';
                }
            });
        });
    });




    const universityTransferredRadio = document.getElementById("university_transferred");
    const vocationalTransferredRadio = document.getElementById("vocational_transferred");
    const newStudentRadio = document.getElementById("new_student");
    const instituteField = document.getElementById("instituteField");

    universityTransferredRadio.addEventListener("change", () => {
        instituteField.style.display = universityTransferredRadio.checked ? "block" : "none";
    });

    vocationalTransferredRadio.addEventListener("change", () => {
        instituteField.style.display = vocationalTransferredRadio.checked ? "block" : "none";
    });

    newStudentRadio.addEventListener("change", () => {
        if (newStudentRadio.checked) {
            instituteField.style.display = "none";
            instituteField.querySelector("input").value = "";
        }
    });





    document.addEventListener("DOMContentLoaded", function () {
        const steps = document.querySelectorAll('.step');
        let currentStep = 0;

        function showStep(stepIndex) {
            steps.forEach((step, index) => {
                step.style.display = index === stepIndex ? 'block' : 'none';
            });
        }

        function updateButtonVisibility() {
            const nextStepBtn = document.getElementById('nextStep');
            const prevStepBtn = document.getElementById('prevStep');

            if (currentStep === 0) {
                prevStepBtn.style.display = 'none';
            } else {
                prevStepBtn.style.display = 'inline';
            }

            if (currentStep === steps.length - 1) {
                nextStepBtn.style.display = 'none';
            } else {
                nextStepBtn.style.display = 'inline';
            }
        }

        function nextStep() {
            console.log("Entered Next Step!");
            if (validateStep(currentStep)) {
                if (currentStep < steps.length - 1) {
                    currentStep++;
                    showStep(currentStep);
                    updateButtonVisibility();
                }
            }
        }

        function prevStep() {
            if (currentStep > 0) {
                currentStep--;
                showStep(currentStep);
            }
        }

        const nextStepBtn = document.getElementById('nextStep');
        nextStepBtn.addEventListener('click', function () {
            nextStep();
            updateButtonVisibility();
        });

        const prevStepBtn = document.getElementById('prevStep');
        prevStepBtn.addEventListener('click', function () {
            prevStep();
            updateButtonVisibility();
        });

        updateButtonVisibility();

    });




    function populateYearSelect(selectId) {
        const select = document.getElementById(selectId);
        const currentYear = new Date().getFullYear();
        for (let year = 1980; year <= currentYear; year++) {
            const option = document.createElement("option");
            option.value = year;
            option.textContent = year;
            select.appendChild(option);
        }
    }

    populateYearSelect("start_year");
    populateYearSelect("end_year");





    const certificateTypeSelect = document.getElementById("certificate_type");
    const academicCertificateFields = document.getElementById("academic_certificate_fields");
    const vocationalCertificateField = document.getElementById("vocational_certificate_fields");
    const vocationalCertificateChoice = document.getElementById("certificate_fields");
    const GraduationDate = document.getElementById("graduation_date");

    certificateTypeSelect.addEventListener("change", function () {
        if (certificateTypeSelect.value === "Academic") {
            academicCertificateFields.style.display = "block";
            vocationalCertificateField.style.display = "none";
            vocationalCertificateChoice.style.display = "none";
            GraduationDate.style.display = "block";
            vocationalCertificateField.querySelector("select").selectedIndex = 0;
            vocationalCertificateChoice.querySelector("select").selectedIndex = 0;
        } else if (certificateTypeSelect.value === "Vocational") {
            academicCertificateFields.style.display = "none";
            vocationalCertificateField.style.display = "block";
            vocationalCertificateChoice.style.display = "block";
            GraduationDate.style.display = "block";
            academicCertificateFields.querySelector("select").selectedIndex = 0;
        } else {
            academicCertificateFields.style.display = "none";
            vocationalCertificateField.style.display = "none";
            vocationalCertificateChoice.style.display = "none";
            GraduationDate.style.display = "none";
            academicCertificateFields.querySelector("select").selectedIndex = 0;
            vocationalCertificateField.querySelector("select").selectedIndex = 0;
            vocationalCertificateChoice.querySelector("select").selectedIndex = 0;
            GraduationDate.querySelector("input").value = null;
        }
    });

    const EnglishCertificateRadios = document.querySelectorAll('input[name="english_certificate"]');
    const FrenchCertificateRadios = document.querySelectorAll('input[name="french_certificate"]');
    const EnglishCertificateNameField = document.getElementById("english_certificate_name");
    const FrenchCertificateNameField = document.getElementById("french_certificate_name");

    EnglishCertificateRadios.forEach(radio => {
        radio.addEventListener("change", function(){
            if(this.value === "Other"){
                EnglishCertificateNameField.style.display = "block";
            }else{
                EnglishCertificateNameField.style.display = "none";
                EnglishCertificateNameField.value = ""; 
            }
        })
    });

    FrenchCertificateRadios.forEach(radio => {
        radio.addEventListener("change", function () {
            if (this.value === "Other") {
                FrenchCertificateNameField.style.display = "block";
            } else {
                FrenchCertificateNameField.style.display = "none";
                FrenchCertificateNameField.value = "";
            }
        })
    });

    const otherInterestCheckbox = document.getElementById("other_interest");
    const otherInterestField = document.getElementById("other_interest_field");

    otherInterestCheckbox.addEventListener("change", () => {
        otherInterestField.style.display = otherInterestCheckbox.checked ? "block" : "none";
    });


    const sensoryDisabilityCheckbox = document.querySelector('input[name="physical_disability[]"][value="Sensory Disability"]');
    const sensoryDisabilityInput = document.getElementById("sensory_disability_specify");

    const physicalDisabilityCheckbox = document.querySelector('input[name="physical_disability[]"][value="Physical Disability"]');
    const physicalDisabilityInput = document.getElementById("physical_disability_specify");

    const otherDisabilityCheckbox = document.getElementById("physical_disability_other_checkbox");
    const otherDisabilityInput = document.getElementById("disability_other_specify");

    sensoryDisabilityCheckbox.addEventListener("change", () => {
        sensoryDisabilityInput.style.display = sensoryDisabilityCheckbox.checked ? "block" : "none";
    });

    physicalDisabilityCheckbox.addEventListener("change", () => {
        physicalDisabilityInput.style.display = physicalDisabilityCheckbox.checked ? "block" : "none";
    });

    otherDisabilityCheckbox.addEventListener("change", () => {
        otherDisabilityInput.style.display = otherDisabilityCheckbox.checked ? "block" : "none";
    });

    // Assume facultiesData contains your faculties data, serialized from the server
    var facultiesData = @Html.Raw(Json.Serialize(Model.faculties));

    // Function to populate the faculties dropdown based on the selected campus
    function populateFacultiesDropdown(selectedCampusId) {
        $('#faculty').empty();
        // Filter faculties based on the selected campusId
        var filteredFaculties = facultiesData.filter(function (faculty) {
            // Log for debugging purposes
            console.log('selectedCampusId:', selectedCampusId);
            console.log('faculty.campusId:', faculty.campusId);
            console.log(faculty.campusId === selectedCampusId);

            return faculty.campusId === selectedCampusId;
        });

        // Log the filtered faculties (for debugging)
        console.log(filteredFaculties);

        // Populate the faculties dropdown with filtered faculties
        if (filteredFaculties.length === 0) {
            $('#faculty').append($('<option>', {
                value: '',
                text: 'Select The Faculty'
            }));
        } else {
            $('#faculty').append($('<option>', {
                value: '',
                text: 'Select The Faculty'
            }));
            filteredFaculties.forEach(function (faculty) {
                $('#faculty').append($('<option>', {
                    value: faculty.facultyId,
                    text: faculty.facultyName
                }));
            });
        }
    }

    // Event handler for the campus dropdown change event
    $('#campus').on('change', function () {
        // Get the selected campus ID as an integer
        var selectedCampusId = parseInt($(this).val(), 10);

        // Log the selected campus ID (for debugging)
        console.log(selectedCampusId);

        // Call the function to populate the faculties dropdown
        populateFacultiesDropdown(selectedCampusId);
        populateDepartmentsDropdown(-1);
        populateMajorsDropdown(-1);
    });

    // Assume departmentsData contains your departments data, serialized from the server
    var DepartmentsData = @Html.Raw(Json.Serialize(Model.departments));

    // Function to populate the departments dropdown based on the selected faculty
    function populateDepartmentsDropdown(selectedFacultyId) {
        $('#department').empty();
        // Filter faculties based on the selected facultyId
        var filteredDepartments = DepartmentsData.filter(function (department) {
            // Log for debugging purposes
            console.log('selectedFacultyId:', selectedFacultyId);
            console.log('department.facultyId:', department.facultyId);
            console.log(department.facultyId === selectedFacultyId);

            return department.facultyId === selectedFacultyId;
        });

        // Log the filtered departments (for debugging)
        console.log(filteredDepartments);

        // Populate the departments dropdown with filtered departments
        if (filteredDepartments.length === 0) {
            $('#department').append($('<option>', {
                value: '',
                text: 'Select Department'
            }));
        } else {
            $('#department').append($('<option>', {
                value: '',
                text: 'Select Department'
            }));
            filteredDepartments.forEach(function (department) {
                $('#department').append($('<option>', {
                    value: department.departmentId,
                    text: department.departmentName
                }));
            });
        }
    }

    // Event handler for the faculty dropdown change event
    $('#faculty').on('change', function () {
        // Get the selected faculty ID as an integer
        var selectedFacultyId = parseInt($(this).val(), 10);

        // Log the selected faculty ID (for debugging)
        console.log(selectedFacultyId);

        // Call the function to populate the departments dropdown
        populateDepartmentsDropdown(selectedFacultyId);
        populateMajorsDropdown(-1);
    });

    // Assume majorsData contains your majors data, serialized from the server
    var majorsData = @Html.Raw(Json.Serialize(Model.majors));

    // Function to populate the majors dropdown based on the selected department
    function populateMajorsDropdown(selectedDepartmentId) {
        $('#major').empty();
        // Filter majors based on the selected facultyId
        var filteredmajors = majorsData.filter(function (major) {
            // Log for debugging purposes
            console.log('selectedDepartmentId:', selectedDepartmentId);
            console.log('major.departmentId:', major.departmentId);
            console.log(major.departmentId === selectedDepartmentId);

            return major.departmentId === selectedDepartmentId;
        });

        // Log the filtered majors (for debugging)
        console.log(filteredmajors);

        // Populate the majors dropdown with filtered majors
        if (filteredmajors.length === 0) {
            $('#major').append($('<option>', {
                value: '',
                text: 'Select The Major'
            }));
        } else {
            $('#major').append($('<option>', {
                value: '',
                text: 'Select The Major'
            }));
            filteredmajors.forEach(function (major) {
                $('#major').append($('<option>', {
                    value: major.majorId,
                    text: major.majorName
                }));
            });
        }
    }

    // Event handler for the department dropdown change event
    $('#department').on('change', function () {
        // Get the selected department ID as an integer
        var selectedDepartmentId = parseInt($(this).val(), 10);

        // Log the selected department ID (for debugging)
        console.log(selectedDepartmentId);

        // Call the function to populate the majors dropdown
        populateMajorsDropdown(selectedDepartmentId);
    });

    // Validation functions for each step
    function validateStep(stepIndex) {

        function validateField(field) {
            if (!field.value.trim()) {
                field.classList.add('error'); // Add a CSS class for highlighting
                isValid = false;
            } else {
                field.classList.remove('error');
            }
        }

        let isValid = true;

        if(stepIndex === 0){
            //Retrieving the elements that need validation
            const firstName = document.getElementById('first_name');
            const middleName = document.getElementById('middle_name');
            const lastName = document.getElementById('last_name');
            const personalEmail = document.getElementById('personal_email');
            const Gender = document.getElementById('gender');
            const motherName = document.getElementById('mother_name');
            const martialStatus = document.getElementById('marital_status');
            const nationality = document.getElementById('nationality');
            const placeOfBirth = document.getElementById('place_of_birth');
            const bloodType = document.getElementById('blood_type');
            const familyRegistration = document.getElementById('family_registration');
            const sociallySecuredYes = document.getElementById('socially_secured_yes');
            const sociallySecuredNo = document.getElementById('socially_secured_no');
            const socialSecurityRadios = document.querySelectorAll('input[name="social_security_type"]');
            const errorDiv = document.getElementById('step1_error');


            //Validate each field
            validateField(firstName);
            validateField(middleName);
            validateField(lastName);
            validateField(motherName);
            validateField(nationality);
            validateField(placeOfBirth);
            validateField(familyRegistration);

            const emailRegex = /^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$/;
            if (!emailFormat.test(personalEmail.value.trim())) {
                personalEmail.classList.add('error');
                emailError.style.display = 'block';
                isValid = false;
            }

            let isSocialSecurityChecked = false;

            if(!sociallySecuredYes.checked && !sociallySecuredNo.checked){
                isValid = false;
            }

            //Check if "Yes" is selected for "Are you socially secured?"
            if (sociallySecuredYes.checked) {
                // Iterate through the social security radio buttons
                socialSecurityRadios.forEach(function (radio) {
                    if (radio.checked) {
                        isSocialSecurityChecked = true;
                    }
                });
            }

            if (sociallySecuredYes.checked && !isSocialSecurityChecked) {
                // Handle the case where the user chose "Yes" but didn't select a social security option
                isValid = false;
            }

            //Display error message if needed
            if(!isValid) {
                errorDiv.style.display = 'block';
            } else {
                errorDiv.style.display = 'none';
            }

            return isValid;
        }


        if(stepIndex === 1){
            const PhoneNumber = document.getElementById('phone_number');
            const EmergencyContactName = document.getElementById('emergency_contact_name');
            const EmergencyPhoneNumber = document.getElementById('emergency_phone_number');
            const City = document.getElementById('city');
            const Area = document.getElementById('area');
            const Street = document.getElementById('street');
            const Nearby = document.getElementById('nearby');
            const Building = document.getElementById('building');
            const Floor = document.getElementById('floor');
            const errorDiv = document.getElementById('step2_error');

            validateField(PhoneNumber);
            validateField(EmergencyContactName);
            validateField(EmergencyPhoneNumber);
            validateField(City);
            validateField(Area);
            validateField(Street);
            validateField(Nearby);
            validateField(Building);
            validateField(Floor);

            if (!isValid) {
                errorDiv.style.display = 'block';
            } else {
                errorDiv.style.display = 'none';
            }

            return isValid;
        }


        if(stepindex == 3){

        }

    }