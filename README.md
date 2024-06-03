# Backend Setup

The backend solution consists of four projects: **WebApi**, **WebApp**, **WebGrpc**, and **Infrastructure**. Follow these steps to set up each project. Make sure you have Microsoft Visual Studio installed.

## Steps

1. **Navigate to the Project Folder**
   Go to your File Explorer and navigate to the project folder.

2. **Open the Project in Visual Studio**
   In the project folder, double-click on the `AspDotNetCore.sln` file. This should open the project in Visual Studio.

3. **View Projects in Solution Explorer**
   Now, in the right sidebar, you will see your four projects.

   ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/7b38d750-cba1-49ed-9f63-586fbd431360)


4. **Rebuild WebApi Project**
   Right-click on the **WebApi** project and click on `Rebuild`.
   
   ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/c0080f96-cb11-47a8-a480-0becbf18f2f3)


5. **Rebuild WebGrpc Project**
   Right-click on the **WebGrpc** project and click on `Rebuild`.
   
   ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/b814f8a0-742b-4d5c-abd1-3c28fafe19b2)


6. **Open Solution Properties**
   Right-click on the Solution and go to properties: `Solution 'AspDotNetCore' (4 of 4 projects) -> Right-click -> Properties`.

   ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/76640943-1f2c-43b4-8844-fc494c69e918)
   ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/8423ef79-5a80-413c-b448-9459499bd97a)


7. **Configure Multiple Startup Projects**
   After clicking on `Properties`, you will see a dialog box. On this dialog box, click on `Multiple startup projects`.

  ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/3430ca34-63f1-49bc-b406-478a499d9b90)


8. **Set Projects to Start**
   Now click on the drop-down for the **WebApi**, **WebApp**, and **WebGrpc** projects and select `Start` for all three of them.

   ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/5ec1b934-3865-4f76-92f3-9d88d9624880)


9. **Apply and Save Changes**
   After selecting `Start` for all three projects, it should look like this.

   ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/0e9520af-d8ed-4db4-9573-efd0998d6132)


10. **Start the Backend Project**
    Click on `Apply` and `Ok` to save the changes.

11. **Launch the Projects**
    Click on `Start` to start your backend project. This should open two browser windows.

    ![image](https://github.com/mohammadfadelkhalaf/BackOfficeBackEnd/assets/74179737/546d6c20-019b-4f74-ba19-b6793fc778dc)


## Conclusion

Following these steps will help you set up the backend solution for your project. Ensure that all dependencies are installed and properly configured.

Feel free to reach out if you encounter any issues during the setup process.
