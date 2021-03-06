﻿using System.Collections.Generic;

namespace Entitas.Utils {

    public abstract class AbstractConfigurableConfig : IConfigurable {

        public abstract Dictionary<string, string> defaultProperties { get; }

        public Properties properties { get { return _properties; } }

        Properties _properties;

        public virtual void Configure(Properties properties) {
            _properties = properties;
        }

        public override string ToString() {
            return properties.ToString();
        }
    }
}
