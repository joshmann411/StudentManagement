# StudentManagement
## Known Error 1
- Due to angular versioning, you might encounter the specified error: 'An unhandled exception occurred: Cannot find module '@angular-devkit/build-angular/package.json'.........'

- To Resolve this:
  -- Run 'npm install --save-dev @angular-devkit/build-angular' then, 
  -- Ensure that the the audit has no severtity instance(s): in such a case that there is: Run 'npm audit fix' to resolve this
  
- Application should then be up and running

## Known Error 2
- If your angular CLI and core is less than v13 do update it to v13 as this project is dependent on the stated version
