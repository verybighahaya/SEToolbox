﻿namespace SEToolbox.ViewModels
{
    using Sandbox.CommonLib.ObjectBuilders;
    using SEToolbox.Models;
    using SEToolbox.Services;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Media.Media3D;

    public class StructureCubeGridViewModel : StructureBaseViewModel<StructureCubeGridModel>
    {
        #region ctor

        public StructureCubeGridViewModel(BaseViewModel parentViewModel, StructureCubeGridModel dataModel)
            : base(parentViewModel, dataModel)
        {
            this.DataModel.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                // Will bubble property change events from the Model to the ViewModel.
                this.OnPropertyChanged(e.PropertyName);
            };
        }

        #endregion

        #region command Properties

        public ICommand RepairObjectCommand
        {
            get
            {
                return new DelegateCommand(new Action(RepairObjectExecuted), new Func<bool>(RepairObjectCanExecute));
            }
        }

        public ICommand ResetVelocityCommand
        {
            get
            {
                return new DelegateCommand(new Action(ResetVelocityExecuted), new Func<bool>(ResetVelocityCanExecute));
            }
        }

        public ICommand ReverseVelocityCommand
        {
            get
            {
                return new DelegateCommand(new Action(ReverseVelocityExecuted), new Func<bool>(ReverseVelocityCanExecute));
            }
        }

        public ICommand MaxVelocityAtPlayerCommand
        {
            get
            {
                return new DelegateCommand(new Action(MaxVelocityAtPlayerExecuted), new Func<bool>(MaxVelocityAtPlayerCanExecute));
            }
        }

        public ICommand ConvertCommand
        {
            get
            {
                return new DelegateCommand(new Action(ConvertExecuted), new Func<bool>(ConvertCanExecute));
            }
        }

        public ICommand ConvertToHeavyArmorCommand
        {
            get
            {
                return new DelegateCommand(new Action(ConvertToHeavyArmorExecuted), new Func<bool>(ConvertToHeavyArmorCanExecute));
            }
        }

        public ICommand ConvertToLightArmorCommand
        {
            get
            {
                return new DelegateCommand(new Action(ConvertToLightArmorExecuted), new Func<bool>(ConvertToLightArmorCanExecute));
            }
        }


        public ICommand ConvertToFrameworkCommand
        {
            get
            {
                return new DelegateCommand(new Action(ConvertToFrameworkExecuted), new Func<bool>(ConvertToFrameworkCanExecute));
            }
        }

        public ICommand ConvertToCompleteStructureCommand
        {
            get
            {
                return new DelegateCommand(new Action(ConvertToCompleteStructureExecuted), new Func<bool>(ConvertToCompleteStructureCanExecute));
            }
        }

        public ICommand ConvertToStationCommand
        {
            get
            {
                return new DelegateCommand(new Action(ConvertToStationExecuted), new Func<bool>(ConvertToStationCanExecute));
            }
        }

        public ICommand ConvertToShipCommand
        {
            get
            {
                return new DelegateCommand(new Action(ConvertToShipExecuted), new Func<bool>(ConvertToShipCanExecute));
            }
        }

        #endregion

        #region Properties

        protected new StructureCubeGridModel DataModel
        {
            get
            {
                return base.DataModel as StructureCubeGridModel;
            }
        }

        public bool IsDamaged
        {
            get
            {
                return this.DataModel.IsDamaged;
            }
        }

        public int DamageCount
        {
            get
            {
                return this.DataModel.DamageCount;
            }
        }

        public Sandbox.CommonLib.ObjectBuilders.MyCubeSize GridSize
        {
            get
            {
                return this.DataModel.GridSize;
            }

            set
            {
                this.DataModel.GridSize = value;
            }
        }

        public bool IsStatic
        {
            get
            {
                return this.DataModel.IsStatic;
            }

            set
            {
                this.DataModel.IsStatic = value;
            }
        }

        public Point3D Min
        {
            get
            {
                return this.DataModel.Min;
            }

            set
            {
                this.DataModel.Min = value;
            }
        }

        public Point3D Max
        {
            get
            {
                return this.DataModel.Max;
            }

            set
            {
                this.DataModel.Max = value;
            }
        }

        public Vector3D Size
        {
            get
            {
                return this.DataModel.Size;
            }

            set
            {
                this.DataModel.Size = value;
            }
        }

        public bool IsPiloted
        {
            get
            {
                return this.DataModel.IsPiloted;
            }
        }

        public double Speed
        {
            get
            {
                return this.DataModel.Speed;
            }
        }

        public double Mass
        {
            get
            {
                return this.DataModel.Mass;
            }
        }

        public string Report
        {
            get
            {
                return this.DataModel.Report;
            }

            set
            {
                this.DataModel.Report = value;
            }
        }

        #endregion

        #region methods

        public bool RepairObjectCanExecute()
        {
            return this.IsDamaged;
        }

        public void RepairObjectExecuted()
        {
            this.DataModel.RepairAllDamage();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool ResetVelocityCanExecute()
        {
            return true;
        }

        public void ResetVelocityExecuted()
        {
            this.DataModel.ResetVelocity();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool ReverseVelocityCanExecute()
        {
            return true;
        }

        public void ReverseVelocityExecuted()
        {
            this.DataModel.ReverseVelocity();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool MaxVelocityAtPlayerCanExecute()
        {
            return true;
        }

        public void MaxVelocityAtPlayerExecuted()
        {
            var position = ((ExplorerViewModel)this.OwnerViewModel).ThePlayerCharacter.PositionAndOrientation.Value.Position;
            this.DataModel.MaxVelocityAtPlayer(position);
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool ConvertCanExecute()
        {
            return true;
        }

        public void ConvertExecuted()
        {
        }

        public bool ConvertToHeavyArmorCanExecute()
        {
            return true;
        }

        public void ConvertToHeavyArmorExecuted()
        {
            this.DataModel.ConvertFromLightToHeavyArmor();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool ConvertToLightArmorCanExecute()
        {
            return true;
        }

        public void ConvertToLightArmorExecuted()
        {
            this.DataModel.ConvertFromHeavyToLightArmor();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool ConvertToFrameworkCanExecute()
        {
            return true;
        }

        public void ConvertToFrameworkExecuted()
        {
            this.DataModel.ConvertToFramework();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool ConvertToCompleteStructureCanExecute()
        {
            return true;
        }

        public void ConvertToCompleteStructureExecuted()
        {
            this.DataModel.ConvertToCompleteStructure();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }


        public bool ConvertToStationCanExecute()
        {
            return !this.DataModel.IsStatic && this.DataModel.GridSize == MyCubeSize.Large;
        }

        public void ConvertToStationExecuted()
        {
            this.DataModel.ConvertToStation();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        public bool ConvertToShipCanExecute()
        {
            return this.DataModel.IsStatic && this.DataModel.GridSize == MyCubeSize.Large;
        }

        public void ConvertToShipExecuted()
        {
            this.DataModel.ConvertToShip();
            ((ExplorerViewModel)this.OwnerViewModel).IsModified = true;
        }

        #endregion
    }
}
