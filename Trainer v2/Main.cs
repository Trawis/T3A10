﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using Utils = Trainer.Utilities;

namespace Trainer
{
    //Your mod should have exactly one class that implements the ModMeta interface
    public class Main : ModMeta
    {
        //This function is used to generate the content in the "Mods" section of the options window
        //The behaviors array contains all behaviours that have been spawned for this mod, one for each implementation
        
        #region Fields

        public static bool opened = false;
        public static GUIWindow pr;
        
        #endregion
        
        public static void Tipka()
        {
            var btn = WindowManager.SpawnButton();
            btn.GetComponentInChildren<Text>().text = "Trainer";
            btn.onClick.AddListener(Prozor);
            WindowManager.AddElementToElement(btn.gameObject, WindowManager.FindElementPath("MainPanel/Holder/FanPanel", null).gameObject, new Rect(164, 0, 70, 32), new Rect(0, 0, 0, 0));
        }
        
        public static void Prozor()
        {
            if (!opened)
            {
                opened = true;
                
                #region Initialization
                
                pr = WindowManager.SpawnWindow();
                pr.InitialTitle = "Trainer v2 Settings, by Trawis";
                pr.TitleText.text = "Trainer v2 Settings, by Trawis";
                pr.NonLocTitle = "Trainer v2 Settings, by Trawis";
                pr.MinSize.x = 670;
                pr.MinSize.y = 550;
                
                List<GameObject> btn = new List<GameObject>(), col1 = new List<GameObject>(), col2 = new List<GameObject>(),
                    col3 = new List<GameObject>();
                
                TrainerBehaviour tb = new TrainerBehaviour();
                
                #endregion
                
                #region Money
                
                Utils.AddInputBox("10000", new Rect(1, 0, 150, 32), input => TrainerBehaviour.novacBox = input);
                
                Utils.AddButton("Add Money", new Rect(161, 0, 150, 32), TrainerBehaviour.IncreaseMoney);
                
                #endregion

                #region Reputation
                
                Utils.AddInputBox("10000", new Rect(1, 32, 150, 32), input => TrainerBehaviour.repBox = input);
                
                Utils.AddButton("Add Reputation", new Rect(161, 32, 150, 32), TrainerBehaviour.AddRep);
                
                #endregion
                
                #region Universal Integer Mods

                //Change product price for my company
                
                Utils.AddInputBox("Product Name Here", new Rect(1, 64, 150, 32), boxText => TrainerBehaviour.price_ProductName = boxText);

                Utils.AddInputBox("10", new Rect(161, 64, 150, 32),
                    boxText => TrainerBehaviour.price_ProductPrice = boxText.ConvertToFloat(boxText));
                    
                Utils.AddLabel("<= This cell is universal for\nPrice, Stock, Active Users", new Rect(322, 64, 400, 32));
                
                Utils.AddButton("Set Product Price", new Rect(1, 96, 150, 32), TrainerBehaviour.SetProductPrice);
                
                Utils.AddButton("Set Product Stock", new Rect(161, 96, 150, 32), TrainerBehaviour.SetProductStock);
                
                Utils.AddButton("Set Active Users", new Rect(322, 96, 150, 32), TrainerBehaviour.AddActiveUsers);
                
                #endregion
                
                #region Maximum

                Utils.AddButton("Max Followers", new Rect(1, 128, 150, 32), TrainerBehaviour.MaxFollowers);
                
                Utils.AddButton("Fix Bugs", new Rect(161, 128, 150, 32), TrainerBehaviour.FixBugs);
                
                Utils.AddButton("Max Code", new Rect(322, 128, 150, 32), TrainerBehaviour.MaxCode);
                
                Utils.AddButton("Max Art", new Rect(483, 128, 150, 32), TrainerBehaviour.MaxArt);
                
                #endregion

                #region Companies
                
                Utils.AddInputBox("Company Name Here", new Rect(1, 160, 150, 32), input => TrainerBehaviour.CompanyText = input);
                
                Utils.AddButton("Takeover Company", new Rect(161, 160, 150, 32), TrainerBehaviour.TakeoverCompany);
                
                Utils.AddButton("Subsidiary Company", new Rect(322, 160, 150, 32), TrainerBehaviour.SubDCompany);
                
                Utils.AddButton("Bankrupt", new Rect(483, 160, 150, 32), TrainerBehaviour.ForceBankrupt);
                
                Utils.AddButton("Bankrupt All", tb.AIBankrupt, ref btn);
                
                #endregion
                
                #region Buttons
                
                Utils.AddButton("Clear all loans", tb.ClearLoans, ref btn);
                
                Utils.AddButton("HR Leaders", tb.HREmployees, ref btn);
                
                Utils.AddButton("Max Employees' Skills", tb.EmployeesToMax, ref btn);

                Utils.AddButton("Remove products", TrainerBehaviour.RemoveSoft, ref btn);
                
                Utils.AddButton("Reset Employees' Age", tb.ResetAgeOfEmployees, ref btn);
                
                Utils.AddButton("Sell products stock", TrainerBehaviour.SellProductsStock, ref btn);
                
                Utils.AddButton("Unlock all furniture", tb.UnlockAll, ref btn);
                
                Utils.AddButton("Unlock all space", tb.UnlockAllSpace, ref btn);
                
                #endregion
                
                #region Employee Management

                Utils.AddCheckBox("Disable Needs", boolean => TrainerBehaviour.LockNeeds = boolean, ref col1);

                Utils.AddCheckBox("Disable Stress", boolean => TrainerBehaviour.LockStress = boolean, ref col1);

                Utils.AddCheckBox("Free Employees", boolean => TrainerBehaviour.FreeEmployees = boolean, ref col1);
                
                Utils.AddCheckBox("Free Staff", boolean => TrainerBehaviour.FreeStaff = boolean, ref col1);
                
                Utils.AddCheckBox("Full Efficiency & Satisfaction", boolean => TrainerBehaviour.LockEffSat = boolean, ref col1);
                
                Utils.AddCheckBox("Lock employees' age", boolean => TrainerBehaviour.LockAge = boolean, ref col1);

                Utils.AddCheckBox("No Vacation", boolean => TrainerBehaviour.NoVacation = boolean, ref col1);
                
                Utils.AddCheckBox("No Sickness", boolean => TrainerBehaviour.NoVacation = boolean, ref col1);
                
                Utils.AddCheckBox("Ultra Efficiency", boolean => TrainerBehaviour.MaxOutEff = boolean, ref col1);
                
                #endregion
                
                #region Room Management
                
                Utils.AddCheckBox("Full Environment", boolean => TrainerBehaviour.FullEnv = boolean, ref col2);
                
                Utils.AddCheckBox("Full Sunlight", boolean => TrainerBehaviour.Fullbright = boolean, ref col2);
                
                Utils.AddCheckBox("Lock temperature to 21", boolean => TrainerBehaviour.TempLock = !TrainerBehaviour.TempLock, ref col2);
                
                Utils.AddCheckBox("No Maintenance", boolean => TrainerBehaviour.NoMaintenance = boolean, ref col2);
                
                Utils.AddCheckBox("Noise Reduction", boolean => TrainerBehaviour.NoiseRed = boolean, ref col2);
                
                Utils.AddCheckBox("Rooms never dirty", boolean => TrainerBehaviour.CleanRooms = boolean, ref col2);
                
                #endregion
                
                #region Company Management
                
                Utils.AddCheckBox("Auto Distribution Deals", boolean => TrainerBehaviour.dDeal = boolean, ref col3);
                
                Utils.AddCheckBox("Free Print", boolean => TrainerBehaviour.FreePrint = boolean, ref col3);
                
                Utils.AddCheckBox("Free Water & Electricity", boolean => TrainerBehaviour.NoWaterElect = boolean, ref col3);
                
                Utils.AddCheckBox("Increase Bookshelf Skill", boolean => TrainerBehaviour.IncBookshelfSkill = boolean, ref col3);
                
                Utils.AddCheckBox("Increase Courier Capacity", boolean => TrainerBehaviour.IncCourierCap = boolean, ref col3);
                
                Utils.AddCheckBox("Increase Print Speed", boolean => TrainerBehaviour.IncPrintSpeed = boolean, ref col3);

                Utils.AddCheckBox("More Hosting Deals", boolean => TrainerBehaviour.MoreHosting = boolean, ref col3);
                
                Utils.AddCheckBox("Reduce Internet Cost", boolean => TrainerBehaviour.RedISPCost = boolean, ref col3);
                
                #endregion
                
                #region Loops

                for (var i = 0; i < btn.Count; i++)
                {
                    var item = btn[i];

                    WindowManager.AddElementToWindow(item, pr, new Rect(1, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                for (int i = 0; i < col1.Count; i++)
                {
                    var item = col1[i];

                    WindowManager.AddElementToWindow(item, pr, new Rect(161, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                for (int i = 0; i < col2.Count; i++)
                {
                    var item = col2[i];

                    WindowManager.AddElementToWindow(item, pr, new Rect(322, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                for (int i = 0; i < col3.Count; i++)
                {
                    var item = col3[i];

                    WindowManager.AddElementToWindow(item, pr, new Rect(483, (i + 7) * 32, 150, 32),
                        new Rect(0, 0, 0, 0));
                }

                #endregion
            }
            else
            {
                pr.Close();
                opened = false;
            }
        }
        
        public void ConstructOptionsScreen(RectTransform parent, ModBehaviour[] behaviours)
        {
            var label = WindowManager.SpawnLabel();
            label.text = "Created by LtPain, edit by Trawis\n\nOptions have been moved to the Main Screen of the game.\nPlease load a game and press 'Trainer' button.";
            WindowManager.AddElementToElement(label.gameObject, parent.gameObject, new Rect(0, 0, 400, 128),
                new Rect(0, 0, 0, 0));
        }

        public string Name => "Trainer V2";
    }
}