using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace PrismUnityApp1
{
    /// <summary>
    /// Adapter that creates a new <see cref="Region"/> and binds all
    /// the views to the adapted <see cref="TabControl"/>.
    /// It also keeps the <see cref="IRegion.ActiveViews"/> and the selected items
    /// of the <see cref="TabControl"/> in sync.
    /// </summary>
    public class TabControlRegionAdapter : RegionAdapterBase<TabControl>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TabControlRegionAdapter"/>.
        /// </summary>
        /// <param name="regionBehaviorFactory">The factory used to create the region behaviors to attach to the created regions.</param>
        public TabControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        /// <summary>
        /// Adapts an <see cref="TabControl"/> to an <see cref="IRegion"/>.
        /// </summary>
        /// <param name="region">The new region being used.</param>
        /// <param name="regionTarget">The object to adapt.</param>
        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
        }

        /// <summary>
        /// Attach new behaviors.
        /// </summary>
        /// <param name="region">The region being used.</param>
        /// <param name="regionTarget">The object to adapt.</param>
        /// <remarks>
        /// This class attaches the base behaviors and also listens for changes in the
        /// activity of the region or the control selection and keeps the in sync.
        /// </remarks>
        protected override void AttachBehaviors(IRegion region, TabControl regionTarget)
        {
            if (region == null)
                throw new ArgumentNullException(nameof(region));

            // Add the behavior that syncs the items source items with the rest of the items
            region.Behaviors.Add(TabControlItemsSourceSyncBehavior.BehaviorKey, new TabControlItemsSourceSyncBehavior()
            {
                HostControl = regionTarget
            });

            base.AttachBehaviors(region, regionTarget);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Region"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="Region"/>.</returns>
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}