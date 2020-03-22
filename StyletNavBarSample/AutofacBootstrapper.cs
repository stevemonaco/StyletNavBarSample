﻿using Autofac;
using Stylet;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StyletNavBarSample
{
    /// <summary>
    /// Bootstrapper base for Autofac IoC
    /// </summary>
    /// <remarks>Original source from Stylet's Bootstrapper project</remarks>
    class AutofacBootstrapper<TRootViewModel> : BootstrapperBase where TRootViewModel : class
    {
        private IContainer container;

        private object _rootViewModel;
        protected virtual object RootViewModel
        {
            get { return this._rootViewModel ?? (this._rootViewModel = this.GetInstance(typeof(TRootViewModel))); }
        }

        protected override void ConfigureBootstrapper()
        {
            var builder = new ContainerBuilder();
            this.DefaultConfigureIoC(builder);
            this.ConfigureIoC(builder);
            this.container = builder.Build();
        }

        /// <summary>
        /// Carries out default configuration of the IoC container. Override if you don't want to do this
        /// </summary>
        protected virtual void DefaultConfigureIoC(ContainerBuilder builder)
        {
            var viewManagerConfig = ConfigureViewManagerConfig();
            builder.RegisterInstance<IViewManager>(new ViewManager(viewManagerConfig));

            builder.RegisterInstance<IWindowManagerConfig>(this).ExternallyOwned();
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MessageBoxViewModel>().As<IMessageBoxViewModel>().ExternallyOwned(); // Not singleton!
            builder.RegisterAssemblyTypes(this.GetType().Assembly).ExternallyOwned();
        }

        protected virtual ViewManagerConfig ConfigureViewManagerConfig()
        {
            return new ViewManagerConfig()
            {
                ViewFactory = this.GetInstance,
                ViewAssemblies = new List<Assembly>() { this.GetType().Assembly }
            };
        }

        /// <summary>
        /// Override to add your own types to the IoC container.
        /// </summary>
        protected virtual void ConfigureIoC(ContainerBuilder builder) { }

        public override object GetInstance(Type type)
        {
            return this.container.Resolve(type);
        }

        protected override void Launch()
        {
            base.Application.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            base.DisplayRootView(this.RootViewModel);
        }

        private void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            ScreenExtensions.TryDispose(this._rootViewModel);
            if (this.container != null)
                this.container.Dispose();

            base.Dispose();
        }
    }
}